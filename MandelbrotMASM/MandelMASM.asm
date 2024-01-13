.data
    x_start REAL4 -2.2
    x_end REAL4 0.8
    y_start REAL4 -1.0
    y_end REAL4 1.0
    absMask DWORD 07FFFFFFFh            ; mask setting only sign bit to 0 - positive number
    columnMask DWORD 0, 1, 2, 3, 4, 5, 6, 7
    TWO REAL4 2.0
    FOUR REAL4 4.0
    WHITE DWORD 255                     ; RGB white

.code

generateMandelMASM PROC ;bmp:QWORD, rowCount:DWORD, rowNum:DWORD, resX:DWORD, resY:DWORD, align:DWORD, iterCount:DWORD

    LOCAL alignment: QWORD
    LOCAL rowCount: DWORD
    LOCAL pixelColors [8]: DWORD 

    ;--------- Prologue ---------
    mov qword ptr [rbp+16], rsp
    mov qword ptr [rbp+24], rsi
    mov qword ptr [rbp+32], rdi
    

    mov r11, [rbp + 56]
    mov alignment, r11

    mov rsi, rcx                        ; RSI = *bmp
    mov rowCount, edx
    
    ;--------- Calculating resX * 3 ---------
    mov eax, 3
    mul r9d                             ; EAX = resX * 3
    
    ;--------- Calculating scale factors ---------
    ; X scale factor
    vbroadcastss ymm0, dword ptr [x_end]
    vbroadcastss ymm1, dword ptr [x_start]
    vsubps ymm0, ymm0, ymm1             ; x_end - x_start
    vbroadcastss ymm3, dword ptr [absMask]
    vandps ymm0, ymm0, ymm3             ; ymm0 = abs(x_end - x_start)
    movd xmm1, r9d                      ; moving resX as scalar to xmm1
    vbroadcastss ymm1, xmm1             ; broadcasting resX to ymm1
    vcvtdq2ps ymm1, ymm1                ; convert DWORD to REAL4
    vdivps ymm0, ymm0, ymm1             ; Scale X: ymm0 = abs(x_end - x_start) / resX

    ; Y scale factor
    vbroadcastss ymm1, dword ptr [y_end]
    vbroadcastss ymm2, dword ptr [y_start]
    vsubps ymm1, ymm1, ymm2             ; y_end - y_start
    vandps ymm1, ymm1, ymm3             ; ymm0 = abs(y_end - y_start)
    movd xmm2, dword ptr [rbp+48]       ; moving resX as scalar to xmm2
    vbroadcastss ymm2, xmm2             ; broadcasting resX to ymm2
    vcvtdq2ps ymm2, ymm2                ; convert DWORD to REAL4
    vdivps ymm1, ymm1, ymm2             ; Scale Y - ymm1 = abs(y_end - y_start) / resY

    ;--------- Preparing for main loop --------- 
    xor r10, r10                        ; current y of C - iterator
    movd xmm8, r8d                      ; moving rowNum as scalar to xmm8
    vbroadcastss ymm8, xmm8             ; broadcasting rowNum to ymm8
    vcvtdq2ps ymm8, ymm8
    vbroadcastss ymm9, dword ptr [y_start]  ; broadcasting y_start to ymm9
    vbroadcastss ymm10, dword ptr [x_start] ; broadcasting x_start to ymm10
    vmovdqu ymm11, ymmword ptr [columnMask] ; load 0, 1, 2, 3, 4, 5, 6, 7 to ymm11 - needed for calculating Re(C)
    vcvtdq2ps ymm11, ymm11              ; convert DWORD to REAL4


    LOOP_ROWS:
        ;--------- Calculating Im(C) --------- 
        movd xmm3, r10d                     ; moving current Y as scalar to xmm3
        vbroadcastss ymm3, xmm3             ; broadcasting Y to ymm3
        vcvtdq2ps ymm3, ymm3                ; convert DWORD to REAL4
        vaddps ymm3, ymm3, ymm8             ; ymm3 = rowNum + y
        vmulps ymm3, ymm3, ymm1             ; ymm3 = (rowNum + y) * scaleY
        vaddps ymm3, ymm3, ymm9             ; Im(C) - ymm3 = (rowNum + y) * yScale + yStart

        xor r11, r11                        ; current x of C - iterator

        LOOP_COLUMNS:
            ;--------- Calculating Re(C) ---------
            movd xmm2, r11d                     ; moving current X as scalar to xmm2
            vbroadcastss ymm2, xmm2             ; broadcasting X to ymm2
            vcvtdq2ps ymm2, ymm2                ; convert DWORD to REAL4
            vaddps ymm2, ymm2, ymm11            ; adding columnMask - makes every value greater than previous one by 1
            vmulps ymm2, ymm2, ymm0             ; ymm2 = x * xScale
            vaddps ymm2, ymm2, ymm10            ; Re(C) - ymm2 = x * xScale + xStart

            xor rcx, rcx                        ; current Z(n) iteration - iterator
            vmovups ymm4, ymm2                  ; ymm4 - Re(Z1) = Re(C)
            vmovups ymm6, ymm3                  ; ymm6 - Im(Z1) = Im(C)

            LOOP_ITERATIONS:
                ;--------- Re(Zn+1) = Re^2(Zn) - Im^2(Zn) + Re(C) ---------
                vmovups ymm5, ymm4
                vmulps ymm5, ymm5, ymm5
                vmovups ymm7, ymm6
                vmulps ymm7, ymm7, ymm7
                vsubps ymm5, ymm5, ymm7
                vaddps ymm5, ymm5, ymm2             ; ymm5 - Re(Zn+1)

                ;--------- Im(Zn+1) = 2 * Re(Zn) * Im(Zn) + Im(C) ---------
                vbroadcastss ymm7, dword ptr [TWO]
                vmulps ymm7, ymm7, ymm4
                vmulps ymm7, ymm7, ymm6
                vaddps ymm7, ymm7, ymm3             ; ymm7 - Im(Zn+1)

                vmovups ymm4, ymm5                  ; Re(Zn) new value
                vmovups ymm6, ymm7                  ; Im(Zn) new value

                ;--------- Checking if number is a part of Mandelbrot Set ---------
                vmulps ymm5, ymm5, ymm5             ; Re^2(Zn)
                vmulps ymm7, ymm7, ymm7             ; Im^2(Zn)
                vaddps ymm5, ymm5, ymm7             ; Re^2(Zn) + Im^2(Zn)
                vbroadcastss ymm12, dword ptr [FOUR] ; broadcasts 4 to ymm12
                vcmpleps ymm12, ymm5, ymm12         ; |Zn|^2 <= 4
                vmovmskps rdi, ymm12                ; moves sign bits to rdi
                cmp rdi, 0                          ; if all sign bits in ymm12 are 0 then all floats are greater than 4
                je SAVE_PIXELS                      ; early bailout 

                inc ecx
                cmp ecx, [rbp + 64]                 ; compare current iteration number with iterCount
                jl LOOP_ITERATIONS

            SAVE_PIXELS: 
            vbroadcastss ymm4, dword ptr [WHITE] ; broadcast ymm4 with RGB white
            vandps ymm12, ymm12, ymm4            ; ymm12 contains either black or white RGB value

            ;--------- Coding bitmap pixels ---------
            xor rcx, rcx                         ; current pixel - iterator
            lea rdi, pixelColors
            vmovdqu ymmword ptr [rdi], ymm12     ; move content of ymm12 to array on stack for quicker iterating

            LOOP_PIXELS:                         ; save values of pixels in bitmap
                mov dl, byte ptr [rdi]
                mov byte ptr [rsi], dl
                mov byte ptr [rsi+1], dl
                mov byte ptr [rsi+2], dl
                
                add rdi, 4
                add rsi, 3
                inc ecx
                cmp ecx, 8
                jl LOOP_PIXELS

            add r11d, 8
            cmp r11d, r9d
            jl LOOP_COLUMNS

        add rsi, alignment          ; add alignment for 24bbp bitmap
        inc r10d
        cmp r10d, rowCount
        jl LOOP_ROWS
    
    
    ;--------- Epilogue ---------
    mov rsp, qword ptr [rbp+16]
    mov rsi, qword ptr [rbp+24]
    mov rdi, qword ptr [rbp+32]
    

    ret
generateMandelMASM endp

end
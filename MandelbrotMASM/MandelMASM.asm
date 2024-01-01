;includelib \masm32\lib\msvcrt.lib
;includelib \masm32\lib\user32.lib
;includelib \masm32\lib\kernel32.lib

.data
    x_start REAL4 -2.2
    x_end REAL4 0.8
    y_start REAL4 -1.0
    y_end REAL4 1.0
    absMask DWORD 07FFFFFFFh            ; mask setting only sign bit to 0 - positive number

.code

generateMandelMASM PROC ;bmp:QWORD, rowCount:DWORD, rowNum:DWORD, resX:DWORD, resY:DWORD, align:DWORD, iterCount:DWORD

    LOCAL alignment: QWORD
    LOCAL rowCount: DWORD
    
    ;--------- Prologue ---------
    push rsp
    mov rsp, rbp
    sub rsp, 16                         ; subtracting number of locals * 8 bytes
    
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
    vdivps ymm0, ymm0, ymm1             ; Scale X - ymm0 = abs(x_end - x_start) / resX

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
    xor r10, r10                        ; current y of c - iterator
    movd xmm8, r8d                      ; moving rowNum as scalar to xmm8
    vbroadcastss ymm8, xmm8             ; broadcasting rowNum to ymm8
    vbroadcastss ymm9, dword ptr [y_start] ; broadcasting y_start to ymm9


    LOOP_ROWS:
        ;--------- Calculating Im(C) --------- 
        movd xmm2, r10d                     ; moving current y as scalar to xmm2
        vbroadcastss ymm2, xmm2             ; broadcasting y to ymm2
        vcvtdq2ps ymm2, ymm2                ; convert DWORD to REAL4
        vaddps ymm2, ymm2, ymm8             ; ymm2 = rowNum + y
        vmulps ymm2, ymm2, ymm1             ; ymm2 = (rowNum + y) * scaleY
        vaddps ymm2, ymm2, ymm9             ; Im(C) - ymm2 = (rowNum + y) * yScale + yStart



        inc r10d
        cmp r10d, rowCount
        jl LOOP_ROWS


    ;--------- Making bitmap image grey ---------
    ;mov r10b, 120  ; value to set every pixel to ??? is it neccessary ???
    ;xor rcx, rcx   ; iterator for inner loop
    ;xor rdi, rdi   ; iterator for outer loop
    ;
    ;OUTER_LOOP:
    ;    INNER_LOOP:
    ;        mov byte ptr [rsi], r10b
    ;        inc rsi
    ;        inc rcx
    ;        cmp ecx, eax
    ;        jl INNER_LOOP
    ;xor rcx, rcx
    ;add rsi, alignment
    ;inc rdi
    ;cmp rdi, rowCount
    ;jl OUTER_LOOP
    
    
    ;--------- Epilogue ---------
    mov rsp, rbp  ; deallocating local data
    pop rsp

    ret
generateMandelMASM endp

end
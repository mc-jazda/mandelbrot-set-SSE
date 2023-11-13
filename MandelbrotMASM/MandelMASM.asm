.code

generateMandelMASM PROC ;bmp:QWORD, rowCount:DWORD, rowNum:DWORD, resX:DWORD, resY:DWORD, align:DWORD, iterCount:DWORD

    LOCAL alignment: QWORD
    LOCAL rowCount: QWORD
    
    ;--------- Prologue ---------
    push rsp
    mov rsp, rbp
    sub rsp, 16     ; subtracting number of locals * 8 bytes
    
    mov r11, [rbp + 56]
    mov alignment, r11

    mov rsi, rcx     ; rsi = *bmp
    mov rowCount, rdx
    
    ;--------- Calculating resX * 3 ---------
    mov eax, 3
    mul r9d     ; eax = resX * 3
    

    ;--------- Making bitmap image grey ---------
    mov r10b, 120  ; value to set every pixel to ??? is it neccessary ???
    xor rcx, rcx   ; iterator for inner loop
    xor rdi, rdi   ; iterator for outer loop
    
    OUTER_LOOP:
        INNER_LOOP:
            mov byte ptr [rsi], r10b
            inc rsi
            inc rcx
            cmp ecx, eax
            jl INNER_LOOP
    xor rcx, rcx
    add rsi, alignment
    inc rdi
    cmp rdi, rowCount
    jl OUTER_LOOP
    
    
    ;--------- Epilogue ---------
    mov rsp, rbp  ; deallocating local data
    pop rsp

    ret
generateMandelMASM endp

end
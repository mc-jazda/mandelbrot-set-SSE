.code
                          ; RCX, RDX, R8, R9, stack
generateMandelMASM proc ; byte* bmp, int rowCount, int rowNum, int resX, int resY, int iterCount
    LOCAL alignment: DWORD
    LOCAL bytesPerRow: DWORD
    
    push rdx 
    mov rsi, rcx ; RSI = bmp*

    ; calculating bitmap alignment
    mov eax, 3
    mul r9d
    mov bytesPerRow, eax
    xor edx, edx
    mov r10d, 4
    div r10d
    mov alignment, edx
    
    pop r11; R11 = rowCount
   
    mov r10b, 120 
    mov rdx, r9 ; RDX = resX
    mov rax, 3
    mul rdx
    xor rcx, rcx
    
    LOOP1:
        mov byte ptr [rsi], r10b
        inc cx
        inc rsi
        cmp ecx, eax
        jle LOOP1

    ret
generateMandelMASM endp

end
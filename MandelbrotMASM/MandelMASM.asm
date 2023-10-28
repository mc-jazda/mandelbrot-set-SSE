.code

generateMandelMASM proc ; byte[] bmp, int resX, int resY, int rowNum, int iterCount
    mov rsi, rcx ; byte[] = RSI
    mov r10, 120

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
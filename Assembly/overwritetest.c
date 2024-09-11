#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

void writeMBR(const char *binFilePath, const char *diskPath) {
    // Open the binary file for reading
    FILE *binFile = fopen(binFilePath, "rb");
    if (binFile == NULL) {
        fprintf(stderr, "Error: Unable to open binary file %s\n", binFilePath);
        exit(EXIT_FAILURE);
    }

    // Open the disk for writing
    HANDLE disk = CreateFile(diskPath, GENERIC_WRITE, 0, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
    if (disk == INVALID_HANDLE_VALUE) {
        fprintf(stderr, "Error: Unable to open disk %s\n", diskPath);
        fclose(binFile);
        exit(EXIT_FAILURE);
    }

    // Read the first 512 bytes (MBR size) from the binary file
    char buffer[512];
    size_t bytesRead = fread(buffer, 1, sizeof(buffer), binFile);
    if (bytesRead != sizeof(buffer)) {
        fprintf(stderr, "Error: Unable to read 512 bytes from %s\n", binFilePath);
        CloseHandle(disk);
        fclose(binFile);
        exit(EXIT_FAILURE);
    }

    // Write the 512 bytes to the disk
    DWORD bytesWritten;
    if (!WriteFile(disk, buffer, sizeof(buffer), &bytesWritten, NULL)) {
        fprintf(stderr, "Error: Unable to write to disk %s\n", diskPath);
        CloseHandle(disk);
        fclose(binFile);
        exit(EXIT_FAILURE);
    }

    if (bytesWritten != sizeof(buffer)) {
        fprintf(stderr, "Error: Only %ld of 512 bytes were written to disk %s\n", bytesWritten, diskPath);
        CloseHandle(disk);
        fclose(binFile);
        exit(EXIT_FAILURE);
    }

    // Close the handles after successful operation
    CloseHandle(disk);
    fclose(binFile);

    printf("MBR successfully written to %s\n", diskPath);
}

int main() {
    // Example: write the `mrsmajor5mbr.bin` file to `\\.\PhysicalDrive0`
    writeMBR("mrsmajor5mbr.bin", "\\\\.\\PhysicalDrive0");
    
    return 0;
}

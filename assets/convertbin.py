from PIL import Image
import sys
import math
import os
import zlib

# Define the DOS 16-color palette
dos_colors = [
    (0x00, 0x00, 0x00),  # 0
    (0x00, 0x00, 0xa8),  # 1
    (0x00, 0xa8, 0x00),  # 2
    (0x00, 0xa8, 0xa8),  # 3
    (0xa8, 0x00, 0x00),  # 4
    (0xa8, 0x00, 0xa8),  # 5
    (0xa8, 0xa8, 0x00),  # 6
    (0xa8, 0xa8, 0xa8),  # 7
    (0x54, 0x54, 0x54),  # 8
    (0x54, 0x54, 0xff),  # 9
    (0x54, 0xff, 0x54),  # 10
    (0x54, 0xff, 0xff),  # 11
    (0xff, 0x54, 0x54),  # 12
    (0xff, 0x54, 0xff),  # 13
    (0xff, 0xff, 0x54),  # 14
    (0xff, 0xff, 0xff)   # 15
]

def color_distance(a, b):
    return math.sqrt(sum((a[i] - b[i]) ** 2 for i in range(3)))

def nearest_color(color):
    nearest = 0
    min_dist = float('inf')
    for i, dos_color in enumerate(dos_colors):
        dist = color_distance(color, dos_color)
        if dist < min_dist:
            min_dist = dist
            nearest = i
    return nearest

def convert_image_to_bin(input_png, output_bin):
    try:
        with Image.open(input_png) as img:
            img = img.convert("RGB")
            img = img.resize((80, 50), Image.NEAREST)
            
            with open(output_bin, 'wb') as bin_file:
                for y in range(0, img.height, 2):
                    for x in range(img.width):
                        color1 = nearest_color(img.getpixel((x, y)))
                        color2 = nearest_color(img.getpixel((x, y + 1))) if y + 1 < img.height else 15
                        byte = (color1 << 4) | color2
                        bin_file.write(bytes([byte]))
            
            print(f"Converted {input_png} to binary file {output_bin}")
    except Exception as e:
        print(f"Error converting {input_png} to binary: {e}")

def combine_binary_files(output_file, *input_files):
    try:
        with open(output_file, 'wb') as outfile:
            for fname in input_files:
                if os.path.exists(fname):
                    with open(fname, 'rb') as infile:
                        data = infile.read()
                        outfile.write(data)
                        print(f"Added {fname} to {output_file}")
                else:
                    print(f"File not found: {fname}")
        print(f"Combined binary files into {output_file}")
    except Exception as e:
        print(f"Error combining binary files: {e}")

def compress(input_file, output_file):
    try:
        with open(input_file, 'rb') as infile:
            data = infile.read()
        
        compressed_data = zlib.compress(data, level=zlib.Z_BEST_COMPRESSION)
        
        with open(output_file, 'wb') as outfile:
            outfile.write(compressed_data)
        
        print(f"Compressed {input_file} to {output_file}")
    except Exception as e:
        print(f"Error compressing file {input_file}: {e}")

def main():
    if len(sys.argv) != 4:
        print("Usage: python script.py output.bin input1.png input2.png")
        sys.exit(1)

    output_file = sys.argv[1]
    input_files = sys.argv[2:4]
    bin_files = []

    # Convert each input PNG image to binary file
    for i, input_file in enumerate(input_files):
        bin_file = f"temp{i}.bin"
        if os.path.exists(input_file):
            convert_image_to_bin(input_file, bin_file)
            if os.path.exists(bin_file):
                bin_files.append(bin_file)
            else:
                print(f"Failed to create binary file: {bin_file}")
        else:
            print(f"Image file not found: {input_file}")

    if not bin_files:
        print("No binary files were created. Exiting.")
        sys.exit(1)

    # Combine all binary files into one output file
    combined_bin_file = "combined.bin"
    combine_binary_files(combined_bin_file, *bin_files)

    # Compress the combined binary file
    compress(combined_bin_file, output_file)

    # Clean up temporary files
    for bin_file in bin_files:
        os.remove(bin_file)
    os.remove(combined_bin_file)

if __name__ == "__main__":
    main()

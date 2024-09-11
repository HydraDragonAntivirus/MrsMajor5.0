from PIL import Image
import sys

def resize_image(input_png, output_png, size=(80, 50)):
    try:
        with Image.open(input_png) as img:
            img = img.resize(size, Image.NEAREST)  # Resize to 80x50
            img.save(output_png)
            print(f"Resized {input_png} to {size} and saved as {output_png}")
    except Exception as e:
        print(f"Error resizing {input_png}: {e}")

def main():
    if len(sys.argv) < 3:
        print("Usage: python convertsmaller.py output1.png output2.png [input1.png input2.png ...]")
        sys.exit(1)

    # Extract output files (first two arguments)
    output_files = sys.argv[1:3]
    # Extract input files (remaining arguments)
    input_files = sys.argv[3:]

    # Ensure we have exactly two output files and two input files
    if len(input_files) != 2 or len(output_files) != 2:
        print("Error: You must provide exactly two input files and two output files.")
        sys.exit(1)

    # Process each pair of input and output files
    for input_file, output_file in zip(input_files, output_files):
        resize_image(input_file, output_file)

if __name__ == "__main__":
    main()

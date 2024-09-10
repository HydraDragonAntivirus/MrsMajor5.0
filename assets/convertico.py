from PIL import Image

# Open the PNG file
png_image = Image.open('MrsMajor5.png')

# Convert to ICO format and save
png_image.save('MrsMajor5.ico', format='ICO')

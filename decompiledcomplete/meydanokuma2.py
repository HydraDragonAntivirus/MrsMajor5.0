import os

def remove_nullable_disable(file_path):
    with open(file_path, 'r', encoding='utf-8') as file:
        lines = file.readlines()

    # 'nullable disable' satırlarını filtrele
    new_lines = [line for line in lines if '#nullable disable' not in line]

    with open(file_path, 'w', encoding='utf-8') as file:
        file.writelines(new_lines)

def process_directory(directory_path):
    # .cs dosyalarını tarar
    for root, dirs, files in os.walk(directory_path):
        for file in files:
            if file.endswith(".cs"):
                file_path = os.path.join(root, file)
                remove_nullable_disable(file_path)
                print(f"Processed: {file_path}")

# Mevcut klasörü işlemek için
current_directory = os.getcwd()
process_directory(current_directory)

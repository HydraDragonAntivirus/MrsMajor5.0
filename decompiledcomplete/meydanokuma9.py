import os

def replace_unicode_brace_close(file_path):
    with open(file_path, 'r', encoding='utf-8') as file:
        content = file.read()

    # \u007D ifadesini } ile değiştir
    new_content = content.replace(r"\u007D", "}")

    with open(file_path, 'w', encoding='utf-8') as file:
        file.write(new_content)

def process_directory(directory_path):
    # .cs dosyalarını tarar
    for root, dirs, files in os.walk(directory_path):
        for file in files:
            if file.endswith(".cs"):
                file_path = os.path.join(root, file)
                replace_unicode_brace_close(file_path)
                print(f"Processed: {file_path}")

# Mevcut klasörü işlemek için
current_directory = os.getcwd()
process_directory(current_directory)

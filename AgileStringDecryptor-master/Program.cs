using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using dnlib.DotNet;
using dnlib.DotNet.Writer;

namespace AgileStringDecryptor
{
    internal static class Program
    {
        private static ModuleDefMD? _moduleDefMd;

        internal static void Main(string[] args)
        {
            Console.Title = "Agile String Decryptor by wwh1004 | Version : 6.x";
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the path to the assembly.");
                Console.ReadLine();
                return;
            }

            try
            {
                _moduleDefMd = ModuleDefMD.Load(args[0], new ModuleCreationOptions
                {
                    TryToLoadPdbFromDisk = false
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading assembly: {ex.Message}");
                Console.ReadLine();
                return;
            }

            try
            {
                RemoveNonAsciiCode();
                HandleUnicodeEscapes();
                SanitizeNames();

                var outputPath = Path.Combine(
                    Path.GetDirectoryName(args[0]) ?? throw new InvalidOperationException("Failed to determine output path."),
                    Path.GetFileNameWithoutExtension(args[0]) + "-Utf8Fixed" + Path.GetExtension(args[0]));

                SaveAs(outputPath);

                Console.WriteLine("[+] Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing assembly: {ex.Message}");
            }
            finally
            {
                _moduleDefMd?.Dispose();
                Console.ReadLine();
            }
        }

        internal static void RemoveNonAsciiCode()
        {
            foreach (var typeDef in _moduleDefMd.Types)
            {
                foreach (var method in typeDef.Methods.Where(m => m.HasBody))
                {
                    var instructions = method.Body.Instructions;
                    for (var i = 0; i < instructions.Count; i++)
                    {
                        if (instructions[i].Operand is string str)
                        {
                            instructions[i].Operand = RemoveNonAsciiCharacters(str);
                        }
                    }
                }
            }
        }

        internal static string RemoveNonAsciiCharacters(string input)
        {
            return new string(input.Where(c => c <= 127).ToArray());
        }

        internal static void HandleUnicodeEscapes()
        {
            foreach (var typeDef in _moduleDefMd.Types)
            {
                foreach (var method in typeDef.Methods.Where(m => m.HasBody))
                {
                    var instructions = method.Body.Instructions;
                    for (var i = 0; i < instructions.Count; i++)
                    {
                        if (instructions[i].Operand is string str)
                        {
                            var decodedString = DecodeUnicodeEscapes(str);
                            instructions[i].Operand = RemoveNonAsciiCharacters(decodedString);
                        }
                    }
                }
            }
        }

        internal static bool ContainsUnicodeEscapes(string input)
        {
            return Regex.IsMatch(input, @"\\u[0-9A-Fa-f]{4}");
        }

        internal static string DecodeUnicodeEscapes(string input)
        {
            return Regex.Replace(input, @"\\u([0-9A-Fa-f]{4})", m =>
            {
                var value = Convert.ToInt32(m.Groups[1].Value, 16);
                return ((char)value).ToString();
            });
        }

        internal static void SanitizeNames()
        {
            foreach (var typeDef in _moduleDefMd.Types.ToArray())
            {
                if (ContainsNonAsciiCharacters(typeDef.Name))
                {
                    Console.WriteLine($"Non-standard type name found: {typeDef.Name}");
                    typeDef.Name = SanitizeName(typeDef.Name);
                }

                foreach (var method in typeDef.Methods.ToArray())
                {
                    if (ContainsNonAsciiCharacters(method.Name))
                    {
                        Console.WriteLine($"Non-standard method name found: {method.Name}");
                        method.Name = SanitizeName(method.Name);
                    }
                }

                foreach (var field in typeDef.Fields.ToArray())
                {
                    if (ContainsNonAsciiCharacters(field.Name))
                    {
                        Console.WriteLine($"Non-standard field name found: {field.Name}");
                        field.Name = SanitizeName(field.Name);
                    }
                }
            }
        }

        internal static bool ContainsNonAsciiCharacters(string input)
        {
            return input.Any(c => c > 127);
        }

        internal static string SanitizeName(string input)
        {
            var sanitized = new StringBuilder();

            foreach (char c in input)
            {
                if (c > 127)
                {
                    sanitized.Append($"_U{(int)c:X4}_");
                }
                else
                {
                    sanitized.Append(c);
                }
            }

            return sanitized.ToString();
        }

        internal static void SaveAs(string fileName)
        {
            try
            {
                if (_moduleDefMd != null)
                {
                    var options = new ModuleWriterOptions(_moduleDefMd)
                    {
                        Logger = DummyLogger.NoThrowInstance
                    };

                    _moduleDefMd.Write(fileName, options);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving assembly: {ex.Message}");
            }
        }
    }
}

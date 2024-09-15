// Decompiled with JetBrains decompiler
// Type: {FE3C441D-DF9D-407b-917D-0B4471A8296C}
// Assembly: mmdropper, Version=1.0.7321.42228, Culture=neutral, PublicKeyToken=null
// MVID: 67C14436-991D-42DC-A31E-001F369439CC
// Assembly location: C:\Users\victim\Documents\GitHub\MrsMajor5.0\AgileStringDecryptor-master\bin\Debug\net48\eulascr-Utf8Fixed.exe

using System;
using System.Reflection;
using System.Reflection.Emit;

public class FE3C441DDF9D407b917D0B4471A8296C
{
    private static ModuleHandle tT4;
    public static string KCU = nameof(FE3C441DDF9D407b917D0B4471A8296C);

    static FE3C441DDF9D407b917D0B4471A8296C()
    {
        tT4 = Assembly.GetExecutingAssembly().GetModules()[0].ModuleHandle;
    }

    [Obfuscation]
    public static void dau(int proxyDelegateTypeToken)
    {
        Type typeFromHandle;
        try
        {
            typeFromHandle = Type.GetTypeFromHandle(tT4.ResolveTypeHandle(33554433 + proxyDelegateTypeToken));
        }
        catch
        {
            return;
        }
        foreach (FieldInfo field in typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField))
        {
            string s = field.Name;
            bool flag = false;
            if (s.EndsWith("%"))
            {
                flag = true;
                s = s.TrimEnd('%');
            }
            uint uint32 = BitConverter.ToUInt32(Convert.FromBase64String(s), 0);
            MethodInfo methodFromHandle;
            try
            {
                methodFromHandle = (MethodInfo)MethodBase.GetMethodFromHandle(tT4.ResolveMethodHandle((int)uint32 + 167772161));
            }
            catch
            {
                continue;
            }
            Delegate @delegate;
            if (methodFromHandle.IsStatic)
            {
                try
                {
                    @delegate = Delegate.CreateDelegate(field.FieldType, methodFromHandle);
                }
                catch
                {
                    continue;
                }
            }
            else
            {
                ParameterInfo[] parameters = methodFromHandle.GetParameters();
                int length = parameters.Length + 1;
                Type[] parameterTypes = new Type[length];
                parameterTypes[0] = typeof(object);
                for (int index = 1; index < length; ++index)
                    parameterTypes[index] = parameters[index - 1].ParameterType;
                DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodFromHandle.ReturnType, parameterTypes, typeFromHandle, true);
                ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
                ilGenerator.Emit(OpCodes.Ldarg_0);
                if (length > 1)
                    ilGenerator.Emit(OpCodes.Ldarg_1);
                if (length > 2)
                    ilGenerator.Emit(OpCodes.Ldarg_2);
                if (length > 3)
                    ilGenerator.Emit(OpCodes.Ldarg_3);
                if (length > 4)
                {
                    for (int index = 4; index < length; ++index)
                        ilGenerator.Emit(OpCodes.Ldarg_S, index);
                }
                ilGenerator.Emit(flag ? OpCodes.Callvirt : OpCodes.Call, methodFromHandle);
                ilGenerator.Emit(OpCodes.Ret);
                try
                {
                    @delegate = dynamicMethod.CreateDelegate(typeFromHandle);
                }
                catch
                {
                    continue;
                }
            }
            try
            {
                field.SetValue(null, @delegate);
            }
            catch
            {
            }
        }
    }
}


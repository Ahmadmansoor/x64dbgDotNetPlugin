Imports System.Runtime.InteropServices

Module TitanEngine
    <DllImport("TitanEngine.dll")> _
    Public Function GetContextData(ByVal IndexOfRegister As UInt32) As IntPtr
    End Function
    <DllImport("TitanEngine.dll")> _
    Public Function TitanGetProcessInformation() As PROCESS_INFORMATION
    End Function



    ' Global.Constant.Structure.Declaration:
    ' Engine.External:
    Public Const UE_STRUCT_PE32STRUCT = 1
    Public Const UE_STRUCT_PE64STRUCT = 2
    Public Const UE_STRUCT_PESTRUCT = 3
    Public Const UE_STRUCT_IMPORTENUMDATA = 4
    Public Const UE_STRUCT_THREAD_ITEM_DATA = 5
    Public Const UE_STRUCT_LIBRARY_ITEM_DATA = 6
    Public Const UE_STRUCT_LIBRARY_ITEM_DATAW = 7
    Public Const UE_STRUCT_PROCESS_ITEM_DATA = 8
    Public Const UE_STRUCT_HANDLERARRAY = 9
    Public Const UE_STRUCT_PLUGININFORMATION = 10
    Public Const UE_STRUCT_HOOK_ENTRY = 11
    Public Const UE_STRUCT_FILE_STATUS_INFO = 12
    Public Const UE_STRUCT_FILE_FIX_INFO = 13
    Public Const UE_STRUCT_X87FPUREGISTER = 14
    Public Const UE_STRUCT_X87FPU = 15
    Public Const UE_STRUCT_TITAN_ENGINE_CONTEXT = 16

    Public Const UE_ACCESS_READ = 0
    Public Const UE_ACCESS_WRITE = 1
    Public Const UE_ACCESS_ALL = 2

    Public Const UE_HIDE_PEBONLY = 0
    Public Const UE_HIDE_BASIC = 1

    Public Const UE_PLUGIN_CALL_REASON_PREDEBUG = 1
    Public Const UE_PLUGIN_CALL_REASON_EXCEPTION = 2
    Public Const UE_PLUGIN_CALL_REASON_POSTDEBUG = 3
    Public Const UE_PLUGIN_CALL_REASON_UNHANDLEDEXCEPTION = 4

    Public Const TEE_HOOK_NRM_JUMP = 1
    Public Const TEE_HOOK_NRM_CALL = 3
    Public Const TEE_HOOK_IAT = 5

    Public Const UE_ENGINE_ALOW_MODULE_LOADING = 1
    Public Const UE_ENGINE_AUTOFIX_FORWARDERS = 2
    Public Const UE_ENGINE_PASS_ALL_EXCEPTIONS = 3
    Public Const UE_ENGINE_NO_CONSOLE_WINDOW = 4
    Public Const UE_ENGINE_BACKUP_FOR_CRITICAL_FUNCTIONS = 5
    Public Const UE_ENGINE_CALL_PLUGIN_CALLBACK = 6
    Public Const UE_ENGINE_RESET_CUSTOM_HANDLER = 7
    Public Const UE_ENGINE_CALL_PLUGIN_DEBUG_CALLBACK = 8
    Public Const UE_ENGINE_SET_DEBUG_PRIVILEGE = 9

    Public Const UE_OPTION_REMOVEALL = 1
    Public Const UE_OPTION_DISABLEALL = 2
    Public Const UE_OPTION_REMOVEALLDISABLED = 3
    Public Const UE_OPTION_REMOVEALLENABLED = 4

    Public Const UE_STATIC_DECRYPTOR_XOR = 1
    Public Const UE_STATIC_DECRYPTOR_SUB = 2
    Public Const UE_STATIC_DECRYPTOR_ADD = 3

    Public Const UE_STATIC_DECRYPTOR_FOREWARD = 1
    Public Const UE_STATIC_DECRYPTOR_BACKWARD = 2

    Public Const UE_STATIC_KEY_SIZE_1 = 1
    Public Const UE_STATIC_KEY_SIZE_2 = 2
    Public Const UE_STATIC_KEY_SIZE_4 = 4
    Public Const UE_STATIC_KEY_SIZE_8 = 8

    Public Const UE_STATIC_APLIB = 1
    Public Const UE_STATIC_APLIB_DEPACK = 2
    Public Const UE_STATIC_LZMA = 3

    Public Const UE_STATIC_HASH_MD5 = 1
    Public Const UE_STATIC_HASH_SHA1 = 2
    Public Const UE_STATIC_HASH_CRC32 = 3

    Public Const UE_RESOURCE_LANGUAGE_ANY = -1

    Public Const UE_PE_OFFSET = 0
    Public Const UE_IMAGEBASE = 1
    Public Const UE_OEP = 2
    Public Const UE_SIZEOFIMAGE = 3
    Public Const UE_SIZEOFHEADERS = 4
    Public Const UE_SIZEOFOPTIONALHEADER = 5
    Public Const UE_SECTIONALIGNMENT = 6
    Public Const UE_IMPORTTABLEADDRESS = 7
    Public Const UE_IMPORTTABLESIZE = 8
    Public Const UE_RESOURCETABLEADDRESS = 9
    Public Const UE_RESOURCETABLESIZE = 10
    Public Const UE_EXPORTTABLEADDRESS = 11
    Public Const UE_EXPORTTABLESIZE = 12
    Public Const UE_TLSTABLEADDRESS = 13
    Public Const UE_TLSTABLESIZE = 14
    Public Const UE_RELOCATIONTABLEADDRESS = 15
    Public Const UE_RELOCATIONTABLESIZE = 16
    Public Const UE_TIMEDATESTAMP = 17
    Public Const UE_SECTIONNUMBER = 18
    Public Const UE_CHECKSUM = 19
    Public Const UE_SUBSYSTEM = 20
    Public Const UE_CHARACTERISTICS = 21
    Public Const UE_NUMBEROFRVAANDSIZES = 22
    Public Const UE_BASEOFCODE = 23
    Public Const UE_BASEOFDATA = 24
    'leaving some enum space here for future additions
    Public Const UE_SECTIONNAME = 40
    Public Const UE_SECTIONVIRTUALOFFSET = 41
    Public Const UE_SECTIONVIRTUALSIZE = 42
    Public Const UE_SECTIONRAWOFFSET = 43
    Public Const UE_SECTIONRAWSIZE = 44
    Public Const UE_SECTIONFLAGS = 45

    Public Const UE_VANOTFOUND = -2

    Public Const UE_CH_BREAKPOINT = 1
    Public Const UE_CH_SINGLESTEP = 2
    Public Const UE_CH_ACCESSVIOLATION = 3
    Public Const UE_CH_ILLEGALINSTRUCTION = 4
    Public Const UE_CH_NONCONTINUABLEEXCEPTION = 5
    Public Const UE_CH_ARRAYBOUNDSEXCEPTION = 6
    Public Const UE_CH_FLOATDENORMALOPERAND = 7
    Public Const UE_CH_FLOATDEVIDEBYZERO = 8
    Public Const UE_CH_INTEGERDEVIDEBYZERO = 9
    Public Const UE_CH_INTEGEROVERFLOW = 10
    Public Const UE_CH_PRIVILEGEDINSTRUCTION = 11
    Public Const UE_CH_PAGEGUARD = 12
    Public Const UE_CH_EVERYTHINGELSE = 13
    Public Const UE_CH_CREATETHREAD = 14
    Public Const UE_CH_EXITTHREAD = 15
    Public Const UE_CH_CREATEPROCESS = 16
    Public Const UE_CH_EXITPROCESS = 17
    Public Const UE_CH_LOADDLL = 18
    Public Const UE_CH_UNLOADDLL = 19
    Public Const UE_CH_OUTPUTDEBUGSTRING = 20
    Public Const UE_CH_AFTEREXCEPTIONPROCESSING = 21
    Public Const UE_CH_SYSTEMBREAKPOINT = 23
    Public Const UE_CH_UNHANDLEDEXCEPTION = 24
    Public Const UE_CH_RIPEVENT = 25
    Public Const UE_CH_DEBUGEVENT = 26

    Public Const UE_OPTION_HANDLER_RETURN_HANDLECOUNT = 1
    Public Const UE_OPTION_HANDLER_RETURN_ACCESS = 2
    Public Const UE_OPTION_HANDLER_RETURN_FLAGS = 3
    Public Const UE_OPTION_HANDLER_RETURN_TYPENAME = 4

    Public Const UE_BREAKPOINT_INT3 = 1
    Public Const UE_BREAKPOINT_LONG_INT3 = 2
    Public Const UE_BREAKPOINT_UD2 = 3

    Public Const UE_BPXREMOVED = 0
    Public Const UE_BPXACTIVE = 1
    Public Const UE_BPXINACTIVE = 2

    Public Const UE_BREAKPOINT = 0
    Public Const UE_SINGLESHOOT = 1
    Public Const UE_HARDWARE = 2
    Public Const UE_MEMORY = 3
    Public Const UE_MEMORY_READ = 4
    Public Const UE_MEMORY_WRITE = 5
    Public Const UE_MEMORY_EXECUTE = 6
    Public Const UE_BREAKPOINT_TYPE_INT3 = &H10000000
    Public Const UE_BREAKPOINT_TYPE_LONG_INT3 = &H20000000
    Public Const UE_BREAKPOINT_TYPE_UD2 = &H30000000

    Public Const UE_HARDWARE_EXECUTE = 4
    Public Const UE_HARDWARE_WRITE = 5
    Public Const UE_HARDWARE_READWRITE = 6

    Public Const UE_HARDWARE_SIZE_1 = 7
    Public Const UE_HARDWARE_SIZE_2 = 8
    Public Const UE_HARDWARE_SIZE_4 = 9
    Public Const UE_HARDWARE_SIZE_8 = 10

    Public Const UE_ON_LIB_LOAD = 1
    Public Const UE_ON_LIB_UNLOAD = 2
    Public Const UE_ON_LIB_ALL = 3

    Public Const UE_APISTART = 0
    Public Const UE_APIEND = 1

    Public Const UE_PLATFORM_x86 = 1
    Public Const UE_PLATFORM_x64 = 2
    Public Const UE_PLATFORM_ALL = 3

    Public Const UE_FUNCTION_STDCALL = 1
    Public Const UE_FUNCTION_CCALL = 2
    Public Const UE_FUNCTION_FASTCALL = 3
    Public Const UE_FUNCTION_STDCALL_RET = 4
    Public Const UE_FUNCTION_CCALL_RET = 5
    Public Const UE_FUNCTION_FASTCALL_RET = 6
    Public Const UE_FUNCTION_STDCALL_CALL = 7
    Public Const UE_FUNCTION_CCALL_CALL = 8
    Public Const UE_FUNCTION_FASTCALL_CALL = 9
    Public Const UE_PARAMETER_BYTE = 0
    Public Const UE_PARAMETER_WORD = 1
    Public Const UE_PARAMETER_DWORD = 2
    Public Const UE_PARAMETER_QWORD = 3
    Public Const UE_PARAMETER_PTR_BYTE = 4
    Public Const UE_PARAMETER_PTR_WORD = 5
    Public Const UE_PARAMETER_PTR_DWORD = 6
    Public Const UE_PARAMETER_PTR_QWORD = 7
    Public Const UE_PARAMETER_STRING = 8
    Public Const UE_PARAMETER_UNICODE = 9

    Public Const UE_EAX = 1
    Public Const UE_EBX = 2
    Public Const UE_ECX = 3
    Public Const UE_EDX = 4
    Public Const UE_EDI = 5
    Public Const UE_ESI = 6
    Public Const UE_EBP = 7
    Public Const UE_ESP = 8
    Public Const UE_EIP = 9
    Public Const UE_EFLAGS = 10
    Public Const UE_DR0 = 11
    Public Const UE_DR1 = 12
    Public Const UE_DR2 = 13
    Public Const UE_DR3 = 14
    Public Const UE_DR6 = 15
    Public Const UE_DR7 = 16
    Public Const UE_RAX = 17
    Public Const UE_RBX = 18
    Public Const UE_RCX = 19
    Public Const UE_RDX = 20
    Public Const UE_RDI = 21
    Public Const UE_RSI = 22
    Public Const UE_RBP = 23
    Public Const UE_RSP = 24
    Public Const UE_RIP = 25
    Public Const UE_RFLAGS = 26
    Public Const UE_R8 = 27
    Public Const UE_R9 = 28
    Public Const UE_R10 = 29
    Public Const UE_R11 = 30
    Public Const UE_R12 = 31
    Public Const UE_R13 = 32
    Public Const UE_R14 = 33
    Public Const UE_R15 = 34
    Public Const UE_CIP = 35
    Public Const UE_CSP = 36
End Module

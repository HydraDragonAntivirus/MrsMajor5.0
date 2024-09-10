/*** Autogenerated by WIDL 9.11 from include/ivectorchangedeventargs.idl - Do not edit ***/

#ifdef _WIN32
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif
#include <rpc.h>
#include <rpcndr.h>
#endif

#ifndef COM_NO_WINDOWS_H
#include <windows.h>
#include <ole2.h>
#endif

#ifndef __ivectorchangedeventargs_h__
#define __ivectorchangedeventargs_h__

#ifndef __WIDL_INLINE
#if defined(__cplusplus) || defined(_MSC_VER)
#define __WIDL_INLINE inline
#elif defined(__GNUC__)
#define __WIDL_INLINE __inline__
#endif
#endif

/* Forward declarations */

#ifndef ____x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_FWD_DEFINED__
#define ____x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_FWD_DEFINED__
typedef interface __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs;
#ifdef __cplusplus
#define __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs ABI::Windows::Foundation::Collections::IVectorChangedEventArgs
namespace ABI {
    namespace Windows {
        namespace Foundation {
            namespace Collections {
                interface IVectorChangedEventArgs;
            }
        }
    }
}
#endif /* __cplusplus */
#endif

/* Headers for imported files */

#include <inspectable.h>
#include <windowscontracts.h>

#ifdef __cplusplus
extern "C" {
#endif

#if WINDOWS_FOUNDATION_FOUNDATIONCONTRACT_VERSION >= 0x10000
#ifdef __cplusplus
} /* extern "C" */
namespace ABI {
    namespace Windows {
        namespace Foundation {
            namespace Collections {
                enum CollectionChange {
                    CollectionChange_Reset = 0,
                    CollectionChange_ItemInserted = 1,
                    CollectionChange_ItemRemoved = 2,
                    CollectionChange_ItemChanged = 3
                };
            }
        }
    }
}
extern "C" {
#else
enum __x_ABI_CWindows_CFoundation_CCollections_CCollectionChange {
    CollectionChange_Reset = 0,
    CollectionChange_ItemInserted = 1,
    CollectionChange_ItemRemoved = 2,
    CollectionChange_ItemChanged = 3
};
#ifdef WIDL_using_Windows_Foundation_Collections
#define CollectionChange __x_ABI_CWindows_CFoundation_CCollections_CCollectionChange
#endif /* WIDL_using_Windows_Foundation_Collections */
#endif

#endif /* WINDOWS_FOUNDATION_FOUNDATIONCONTRACT_VERSION >= 0x10000 */
#ifndef __cplusplus
typedef enum __x_ABI_CWindows_CFoundation_CCollections_CCollectionChange __x_ABI_CWindows_CFoundation_CCollections_CCollectionChange;
#endif /* __cplusplus */

/*****************************************************************************
 * IVectorChangedEventArgs interface
 */
#if WINDOWS_FOUNDATION_FOUNDATIONCONTRACT_VERSION >= 0x10000
#ifndef ____x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_INTERFACE_DEFINED__
#define ____x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_INTERFACE_DEFINED__

DEFINE_GUID(IID___x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs, 0x575933df, 0x34fe, 0x4480, 0xaf,0x15, 0x07,0x69,0x1f,0x3d,0x5d,0x9b);
#if defined(__cplusplus) && !defined(CINTERFACE)
} /* extern "C" */
namespace ABI {
    namespace Windows {
        namespace Foundation {
            namespace Collections {
                MIDL_INTERFACE("575933df-34fe-4480-af15-07691f3d5d9b")
                IVectorChangedEventArgs : public IInspectable
                {
                    virtual HRESULT STDMETHODCALLTYPE get_CollectionChange(
                        enum CollectionChange *value) = 0;

                    virtual HRESULT STDMETHODCALLTYPE get_Index(
                        unsigned int *value) = 0;

                };
            }
        }
    }
}
extern "C" {
#ifdef __CRT_UUID_DECL
__CRT_UUID_DECL(__x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs, 0x575933df, 0x34fe, 0x4480, 0xaf,0x15, 0x07,0x69,0x1f,0x3d,0x5d,0x9b)
#endif
#else
typedef struct __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgsVtbl {
    BEGIN_INTERFACE

    /*** IUnknown methods ***/
    HRESULT (STDMETHODCALLTYPE *QueryInterface)(
        __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs *This,
        REFIID riid,
        void **ppvObject);

    ULONG (STDMETHODCALLTYPE *AddRef)(
        __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs *This);

    ULONG (STDMETHODCALLTYPE *Release)(
        __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs *This);

    /*** IInspectable methods ***/
    HRESULT (STDMETHODCALLTYPE *GetIids)(
        __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs *This,
        ULONG *iidCount,
        IID **iids);

    HRESULT (STDMETHODCALLTYPE *GetRuntimeClassName)(
        __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs *This,
        HSTRING *className);

    HRESULT (STDMETHODCALLTYPE *GetTrustLevel)(
        __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs *This,
        TrustLevel *trustLevel);

    /*** IVectorChangedEventArgs methods ***/
    HRESULT (STDMETHODCALLTYPE *get_CollectionChange)(
        __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs *This,
        enum __x_ABI_CWindows_CFoundation_CCollections_CCollectionChange *value);

    HRESULT (STDMETHODCALLTYPE *get_Index)(
        __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs *This,
        unsigned int *value);

    END_INTERFACE
} __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgsVtbl;

interface __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs {
    CONST_VTBL __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgsVtbl* lpVtbl;
};

#ifdef COBJMACROS
#ifndef WIDL_C_INLINE_WRAPPERS
/*** IUnknown methods ***/
#define __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_QueryInterface(This,riid,ppvObject) (This)->lpVtbl->QueryInterface(This,riid,ppvObject)
#define __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_AddRef(This) (This)->lpVtbl->AddRef(This)
#define __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_Release(This) (This)->lpVtbl->Release(This)
/*** IInspectable methods ***/
#define __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_GetIids(This,iidCount,iids) (This)->lpVtbl->GetIids(This,iidCount,iids)
#define __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_GetRuntimeClassName(This,className) (This)->lpVtbl->GetRuntimeClassName(This,className)
#define __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_GetTrustLevel(This,trustLevel) (This)->lpVtbl->GetTrustLevel(This,trustLevel)
/*** IVectorChangedEventArgs methods ***/
#define __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_get_CollectionChange(This,value) (This)->lpVtbl->get_CollectionChange(This,value)
#define __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_get_Index(This,value) (This)->lpVtbl->get_Index(This,value)
#else
/*** IUnknown methods ***/
static __WIDL_INLINE HRESULT __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_QueryInterface(__x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs* This,REFIID riid,void **ppvObject) {
    return This->lpVtbl->QueryInterface(This,riid,ppvObject);
}
static __WIDL_INLINE ULONG __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_AddRef(__x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs* This) {
    return This->lpVtbl->AddRef(This);
}
static __WIDL_INLINE ULONG __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_Release(__x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs* This) {
    return This->lpVtbl->Release(This);
}
/*** IInspectable methods ***/
static __WIDL_INLINE HRESULT __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_GetIids(__x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs* This,ULONG *iidCount,IID **iids) {
    return This->lpVtbl->GetIids(This,iidCount,iids);
}
static __WIDL_INLINE HRESULT __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_GetRuntimeClassName(__x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs* This,HSTRING *className) {
    return This->lpVtbl->GetRuntimeClassName(This,className);
}
static __WIDL_INLINE HRESULT __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_GetTrustLevel(__x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs* This,TrustLevel *trustLevel) {
    return This->lpVtbl->GetTrustLevel(This,trustLevel);
}
/*** IVectorChangedEventArgs methods ***/
static __WIDL_INLINE HRESULT __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_get_CollectionChange(__x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs* This,enum __x_ABI_CWindows_CFoundation_CCollections_CCollectionChange *value) {
    return This->lpVtbl->get_CollectionChange(This,value);
}
static __WIDL_INLINE HRESULT __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_get_Index(__x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs* This,unsigned int *value) {
    return This->lpVtbl->get_Index(This,value);
}
#endif
#ifdef WIDL_using_Windows_Foundation_Collections
#define IID_IVectorChangedEventArgs IID___x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs
#define IVectorChangedEventArgsVtbl __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgsVtbl
#define IVectorChangedEventArgs __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs
#define IVectorChangedEventArgs_QueryInterface __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_QueryInterface
#define IVectorChangedEventArgs_AddRef __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_AddRef
#define IVectorChangedEventArgs_Release __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_Release
#define IVectorChangedEventArgs_GetIids __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_GetIids
#define IVectorChangedEventArgs_GetRuntimeClassName __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_GetRuntimeClassName
#define IVectorChangedEventArgs_GetTrustLevel __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_GetTrustLevel
#define IVectorChangedEventArgs_get_CollectionChange __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_get_CollectionChange
#define IVectorChangedEventArgs_get_Index __x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_get_Index
#endif /* WIDL_using_Windows_Foundation_Collections */
#endif

#endif

#endif  /* ____x_ABI_CWindows_CFoundation_CCollections_CIVectorChangedEventArgs_INTERFACE_DEFINED__ */
#endif /* WINDOWS_FOUNDATION_FOUNDATIONCONTRACT_VERSION >= 0x10000 */

/* Begin additional prototypes for all interfaces */


/* End additional prototypes */

#ifdef __cplusplus
}
#endif

#endif /* __ivectorchangedeventargs_h__ */

/*** Autogenerated by WIDL 9.11 from include/wmpservices.idl - Do not edit ***/

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

#ifndef __wmpservices_h__
#define __wmpservices_h__

#ifndef __WIDL_INLINE
#if defined(__cplusplus) || defined(_MSC_VER)
#define __WIDL_INLINE inline
#elif defined(__GNUC__)
#define __WIDL_INLINE __inline__
#endif
#endif

/* Forward declarations */

#ifndef __IWMPGraphCreation_FWD_DEFINED__
#define __IWMPGraphCreation_FWD_DEFINED__
typedef interface IWMPGraphCreation IWMPGraphCreation;
#ifdef __cplusplus
interface IWMPGraphCreation;
#endif /* __cplusplus */
#endif

/* Headers for imported files */

#include <oaidl.h>
#include <ocidl.h>

#ifdef __cplusplus
extern "C" {
#endif

#define WMPGC_FLAGS_SUPPRESS_DIALOGS 0x00000002
/*****************************************************************************
 * IWMPGraphCreation interface
 */
#ifndef __IWMPGraphCreation_INTERFACE_DEFINED__
#define __IWMPGraphCreation_INTERFACE_DEFINED__

DEFINE_GUID(IID_IWMPGraphCreation, 0xbfb377e5, 0xc594, 0x4369, 0xa9,0x70, 0xde,0x89,0x6d,0x5e,0xce,0x74);
#if defined(__cplusplus) && !defined(CINTERFACE)
MIDL_INTERFACE("bfb377e5-c594-4369-a970-de896d5ece74")
IWMPGraphCreation : public IUnknown
{
    virtual HRESULT STDMETHODCALLTYPE GraphCreationPreRender(
        IUnknown *filter_graph,
        IUnknown *reserved) = 0;

    virtual HRESULT STDMETHODCALLTYPE GraphCreationPostRender(
        IUnknown *filter_graph) = 0;

    virtual HRESULT STDMETHODCALLTYPE GetGraphCreationFlags(
        DWORD *flags) = 0;

};
#ifdef __CRT_UUID_DECL
__CRT_UUID_DECL(IWMPGraphCreation, 0xbfb377e5, 0xc594, 0x4369, 0xa9,0x70, 0xde,0x89,0x6d,0x5e,0xce,0x74)
#endif
#else
typedef struct IWMPGraphCreationVtbl {
    BEGIN_INTERFACE

    /*** IUnknown methods ***/
    HRESULT (STDMETHODCALLTYPE *QueryInterface)(
        IWMPGraphCreation *This,
        REFIID riid,
        void **ppvObject);

    ULONG (STDMETHODCALLTYPE *AddRef)(
        IWMPGraphCreation *This);

    ULONG (STDMETHODCALLTYPE *Release)(
        IWMPGraphCreation *This);

    /*** IWMPGraphCreation methods ***/
    HRESULT (STDMETHODCALLTYPE *GraphCreationPreRender)(
        IWMPGraphCreation *This,
        IUnknown *filter_graph,
        IUnknown *reserved);

    HRESULT (STDMETHODCALLTYPE *GraphCreationPostRender)(
        IWMPGraphCreation *This,
        IUnknown *filter_graph);

    HRESULT (STDMETHODCALLTYPE *GetGraphCreationFlags)(
        IWMPGraphCreation *This,
        DWORD *flags);

    END_INTERFACE
} IWMPGraphCreationVtbl;

interface IWMPGraphCreation {
    CONST_VTBL IWMPGraphCreationVtbl* lpVtbl;
};

#ifdef COBJMACROS
#ifndef WIDL_C_INLINE_WRAPPERS
/*** IUnknown methods ***/
#define IWMPGraphCreation_QueryInterface(This,riid,ppvObject) (This)->lpVtbl->QueryInterface(This,riid,ppvObject)
#define IWMPGraphCreation_AddRef(This) (This)->lpVtbl->AddRef(This)
#define IWMPGraphCreation_Release(This) (This)->lpVtbl->Release(This)
/*** IWMPGraphCreation methods ***/
#define IWMPGraphCreation_GraphCreationPreRender(This,filter_graph,reserved) (This)->lpVtbl->GraphCreationPreRender(This,filter_graph,reserved)
#define IWMPGraphCreation_GraphCreationPostRender(This,filter_graph) (This)->lpVtbl->GraphCreationPostRender(This,filter_graph)
#define IWMPGraphCreation_GetGraphCreationFlags(This,flags) (This)->lpVtbl->GetGraphCreationFlags(This,flags)
#else
/*** IUnknown methods ***/
static __WIDL_INLINE HRESULT IWMPGraphCreation_QueryInterface(IWMPGraphCreation* This,REFIID riid,void **ppvObject) {
    return This->lpVtbl->QueryInterface(This,riid,ppvObject);
}
static __WIDL_INLINE ULONG IWMPGraphCreation_AddRef(IWMPGraphCreation* This) {
    return This->lpVtbl->AddRef(This);
}
static __WIDL_INLINE ULONG IWMPGraphCreation_Release(IWMPGraphCreation* This) {
    return This->lpVtbl->Release(This);
}
/*** IWMPGraphCreation methods ***/
static __WIDL_INLINE HRESULT IWMPGraphCreation_GraphCreationPreRender(IWMPGraphCreation* This,IUnknown *filter_graph,IUnknown *reserved) {
    return This->lpVtbl->GraphCreationPreRender(This,filter_graph,reserved);
}
static __WIDL_INLINE HRESULT IWMPGraphCreation_GraphCreationPostRender(IWMPGraphCreation* This,IUnknown *filter_graph) {
    return This->lpVtbl->GraphCreationPostRender(This,filter_graph);
}
static __WIDL_INLINE HRESULT IWMPGraphCreation_GetGraphCreationFlags(IWMPGraphCreation* This,DWORD *flags) {
    return This->lpVtbl->GetGraphCreationFlags(This,flags);
}
#endif
#endif

#endif


#endif  /* __IWMPGraphCreation_INTERFACE_DEFINED__ */

/* Begin additional prototypes for all interfaces */


/* End additional prototypes */

#ifdef __cplusplus
}
#endif

#endif /* __wmpservices_h__ */

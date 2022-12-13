## .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
```assembly
; Benchmarks.Microsoft.Azure.Cosmos.PartitionKey_Instantiation.New()
;             return new PartitionKey(0);
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rsi,rdx
       mov       rcx,offset MT_System.Double
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       xor       ecx,ecx
       mov       [rdi+8],rcx
       mov       rcx,offset MT_Microsoft.Azure.Documents.PartitionKey
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       mov       rcx,rdi
       mov       edx,1
       call      Microsoft.Azure.Documents.Routing.PartitionKeyInternal.FromObject(System.Object, Boolean)
       lea       rcx,[rbx+8]
       mov       rdx,rax
       call      CORINFO_HELP_ASSIGN_REF
       mov       rdx,[rbx+8]
       xor       edi,edi
       mov       rcx,rsi
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
       mov       [rsi+8],dil
       mov       rax,rsi
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 106
```
```assembly
; Microsoft.Azure.Documents.Routing.PartitionKeyInternal.FromObject(System.Object, Boolean)
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rsi,rcx
       mov       edi,edx
       mov       rcx,offset MT_System.Collections.Generic.List`1[[Microsoft.Azure.Documents.Routing.IPartitionKeyComponent, Microsoft.Azure.Cosmos.Direct]]
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       mov       rcx,offset MT_Microsoft.Azure.Documents.Routing.IPartitionKeyComponent[]
       mov       edx,1
       call      CORINFO_HELP_NEWARR_1_OBJ
       lea       rcx,[rbx+8]
       mov       rdx,rax
       call      CORINFO_HELP_ASSIGN_REF
       movzx     edx,dil
       mov       rcx,rsi
       call      Microsoft.Azure.Documents.Routing.PartitionKeyInternal.FromObjectToPartitionKeyComponent(System.Object, Boolean)
       mov       r8,rax
       inc       dword ptr [rbx+14]
       mov       rcx,[rbx+8]
       mov       edx,[rbx+10]
       cmp       [rcx+8],edx
       jbe       short M01_L00
       lea       eax,[rdx+1]
       mov       [rbx+10],eax
       call      CORINFO_HELP_ARRADDR_ST
       jmp       short M01_L01
M01_L00:
       mov       rcx,rbx
       mov       rdx,r8
       call      System.Collections.Generic.List`1[[System.__Canon, System.Private.CoreLib]].AddWithResize(System.__Canon)
M01_L01:
       mov       rcx,offset MT_Microsoft.Azure.Documents.Routing.PartitionKeyInternal
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       lea       rcx,[rsi+8]
       mov       rdx,rbx
       call      CORINFO_HELP_ASSIGN_REF
       mov       rax,rsi
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 157
```

## .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
```assembly
; Benchmarks.Microsoft.Azure.Cosmos.PartitionKey_Instantiation.Default()
;             return default;
;             ^^^^^^^^^^^^^^^
       xor       eax,eax
       xor       ecx,ecx
       mov       [rdx],rcx
       mov       [rdx+8],al
       mov       rax,rdx
       ret
; Total bytes of code 14
```

## .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
```assembly
; Benchmarks.Microsoft.Azure.Cosmos.PartitionKey_Instantiation.Field()
;             return _partitionKey;
;             ^^^^^^^^^^^^^^^^^^^^^
       push      rdi
       push      rsi
       push      rbx
       mov       rbx,rdx
       lea       rsi,[rcx+8]
       mov       rdi,rbx
       call      CORINFO_HELP_ASSIGN_BYREF
       movsq
       mov       rax,rbx
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 27
```

## .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
```assembly
; Benchmarks.Microsoft.Azure.Cosmos.PartitionKey_Instantiation.FieldInt()
;             return new(NumberZero);
;             ^^^^^^^^^^^^^^^^^^^^^^^
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rsi,rdx
       mov       rcx,offset MT_System.Double
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       xor       ecx,ecx
       mov       [rdi+8],rcx
       mov       rcx,offset MT_Microsoft.Azure.Documents.PartitionKey
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       mov       rcx,rdi
       mov       edx,1
       call      Microsoft.Azure.Documents.Routing.PartitionKeyInternal.FromObject(System.Object, Boolean)
       lea       rcx,[rbx+8]
       mov       rdx,rax
       call      CORINFO_HELP_ASSIGN_REF
       mov       rdx,[rbx+8]
       xor       edi,edi
       mov       rcx,rsi
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
       mov       [rsi+8],dil
       mov       rax,rsi
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 106
```
```assembly
; Microsoft.Azure.Documents.Routing.PartitionKeyInternal.FromObject(System.Object, Boolean)
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       rsi,rcx
       mov       edi,edx
       mov       rcx,offset MT_System.Collections.Generic.List`1[[Microsoft.Azure.Documents.Routing.IPartitionKeyComponent, Microsoft.Azure.Cosmos.Direct]]
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       mov       rcx,offset MT_Microsoft.Azure.Documents.Routing.IPartitionKeyComponent[]
       mov       edx,1
       call      CORINFO_HELP_NEWARR_1_OBJ
       lea       rcx,[rbx+8]
       mov       rdx,rax
       call      CORINFO_HELP_ASSIGN_REF
       movzx     edx,dil
       mov       rcx,rsi
       call      Microsoft.Azure.Documents.Routing.PartitionKeyInternal.FromObjectToPartitionKeyComponent(System.Object, Boolean)
       mov       r8,rax
       inc       dword ptr [rbx+14]
       mov       rcx,[rbx+8]
       mov       edx,[rbx+10]
       cmp       [rcx+8],edx
       jbe       short M01_L00
       lea       eax,[rdx+1]
       mov       [rbx+10],eax
       call      CORINFO_HELP_ARRADDR_ST
       jmp       short M01_L01
M01_L00:
       mov       rcx,rbx
       mov       rdx,r8
       call      System.Collections.Generic.List`1[[System.__Canon, System.Private.CoreLib]].AddWithResize(System.__Canon)
M01_L01:
       mov       rcx,offset MT_Microsoft.Azure.Documents.Routing.PartitionKeyInternal
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       lea       rcx,[rsi+8]
       mov       rdx,rbx
       call      CORINFO_HELP_ASSIGN_REF
       mov       rax,rsi
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 157
```


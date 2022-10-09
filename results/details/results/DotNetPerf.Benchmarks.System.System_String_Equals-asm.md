## .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2
```assembly
; DotNetPerf.Benchmarks.System.System_String_Equals.Sign()
       push      rdi
       push      rsi
       sub       rsp,28
       mov       rsi,rcx
;             bool result = false;
;             ^^^^^^^^^^^^^^^^^^^^
       xor       edi,edi
;                 result = _values1[i] == _values2[i];
;                 ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
M00_L00:
       mov       r8,[rsi+8]
       cmp       edi,[r8+8]
       jae       short M00_L05
       movsxd    rcx,edi
       mov       r8,[r8+rcx*8+10]
       mov       rdx,[rsi+10]
       cmp       edi,[rdx+8]
       jae       short M00_L05
       mov       rdx,[rdx+rcx*8+10]
       cmp       r8,rdx
       jne       short M00_L01
       mov       eax,1
       jmp       short M00_L04
M00_L01:
       test      r8,r8
       je        short M00_L02
       test      rdx,rdx
       je        short M00_L02
       mov       ecx,[r8+8]
       cmp       ecx,[rdx+8]
       je        short M00_L03
M00_L02:
       xor       eax,eax
       jmp       short M00_L04
M00_L03:
       add       r8,0C
       mov       [rsp+20],r8
       add       rdx,0C
       add       ecx,ecx
       mov       r8d,ecx
       mov       rcx,[rsp+20]
       call      System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       movzx     eax,al
;             for (int i = 0; i < TotalItemsToTest; i++)
;                                                   ^^^
M00_L04:
       inc       edi
       cmp       edi,1E
       jl        short M00_L00
       add       rsp,28
       pop       rsi
       pop       rdi
       ret
M00_L05:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 129
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       vzeroupper
       cmp       r8,8
       jb        short M01_L03
       cmp       rcx,rdx
       je        near ptr M01_L07
       cmp       r8,20
       jae       short M01_L00
       cmp       r8,10
       jb        near ptr M01_L14
       jmp       near ptr M01_L09
M01_L00:
       xor       eax,eax
       add       r8,0FFFFFFFFFFFFFFE0
       je        short M01_L02
M01_L01:
       vmovupd   ymm0,[rcx+rax]
       vmovupd   ymm1,[rdx+rax]
       vpcmpeqb  ymm0,ymm0,ymm1
       vpmovmskb r9d,ymm0
       cmp       r9d,0FFFFFFFF
       jne       short M01_L08
       add       rax,20
       cmp       r8,rax
       ja        short M01_L01
M01_L02:
       vmovupd   ymm0,[rcx+r8]
       vmovupd   ymm1,[rdx+r8]
       vpcmpeqb  ymm0,ymm0,ymm1
       vpmovmskb ecx,ymm0
       cmp       ecx,0FFFFFFFF
       jne       short M01_L08
       jmp       short M01_L07
M01_L03:
       cmp       r8,4
       jae       short M01_L11
       xor       eax,eax
       mov       r9,r8
       and       r9,2
       je        short M01_L04
       movzx     eax,word ptr [rcx]
       movzx     r10d,word ptr [rdx]
       sub       eax,r10d
M01_L04:
       test      r8b,1
       jne       short M01_L06
M01_L05:
       test      eax,eax
       sete      al
       movzx     eax,al
       jmp       short M01_L12
M01_L06:
       movzx     r8d,byte ptr [rcx+r9]
       movzx     ecx,byte ptr [rdx+r9]
       sub       r8d,ecx
       or        r8d,eax
       mov       eax,r8d
       jmp       short M01_L05
M01_L07:
       mov       eax,1
       vzeroupper
       ret
M01_L08:
       xor       eax,eax
       vzeroupper
       ret
M01_L09:
       xor       eax,eax
       lea       r9,[r8-10]
       test      r9,r9
       jne       short M01_L13
M01_L10:
       vmovupd   xmm0,[rcx+r9]
       vmovupd   xmm1,[rdx+r9]
       vpcmpeqb  xmm0,xmm0,xmm1
       vpmovmskb r8d,xmm0
       cmp       r8d,0FFFF
       jne       short M01_L08
       jmp       short M01_L07
M01_L11:
       lea       rax,[r8-4]
       mov       r9d,[rcx]
       sub       r9d,[rdx]
       mov       ecx,[rcx+rax]
       sub       ecx,[rdx+rax]
       or        r9d,ecx
       sete      al
       movzx     eax,al
M01_L12:
       vzeroupper
       ret
M01_L13:
       vmovupd   xmm0,[rcx+rax]
       vmovupd   xmm1,[rdx+rax]
       vpcmpeqb  xmm0,xmm0,xmm1
       vpmovmskb r8d,xmm0
       cmp       r8d,0FFFF
       jne       short M01_L08
       add       rax,10
       cmp       r9,rax
       ja        short M01_L13
       jmp       short M01_L10
M01_L14:
       lea       rax,[r8-8]
       mov       r8,[rcx]
       sub       r8,[rdx]
       mov       rcx,[rcx+rax]
       sub       rcx,[rdx+rax]
       or        r8,rcx
       sete      al
       movzx     eax,al
       jmp       short M01_L12
; Total bytes of code 324
```

## .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2
```assembly
; DotNetPerf.Benchmarks.System.System_String_Equals.InstEquals()
       push      rdi
       push      rsi
       sub       rsp,28
       mov       rsi,rcx
;             bool result = false;
;             ^^^^^^^^^^^^^^^^^^^^
       xor       edi,edi
;                 result = _values1[i].Equals(_values2[i]);
;                 ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
M00_L00:
       mov       r8,[rsi+8]
       cmp       edi,[r8+8]
       jae       short M00_L05
       movsxd    rcx,edi
       mov       r8,[r8+rcx*8+10]
       mov       rdx,[rsi+10]
       cmp       edi,[rdx+8]
       jae       short M00_L05
       mov       rdx,[rdx+rcx*8+10]
       cmp       [r8],r8d
       cmp       r8,rdx
       jne       short M00_L01
       mov       eax,1
       jmp       short M00_L04
M00_L01:
       test      rdx,rdx
       jne       short M00_L02
       xor       eax,eax
       jmp       short M00_L04
M00_L02:
       mov       ecx,[r8+8]
       cmp       ecx,[rdx+8]
       je        short M00_L03
       xor       eax,eax
       jmp       short M00_L04
M00_L03:
       add       r8,0C
       mov       [rsp+20],r8
       add       rdx,0C
       add       ecx,ecx
       mov       r8d,ecx
       mov       rcx,[rsp+20]
       call      System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       movzx     eax,al
;             for (int i = 0; i < TotalItemsToTest; i++)
;                                                   ^^^
M00_L04:
       inc       edi
       cmp       edi,1E
       jl        short M00_L00
       add       rsp,28
       pop       rsi
       pop       rdi
       ret
M00_L05:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 131
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       vzeroupper
       cmp       r8,8
       jb        short M01_L03
       cmp       rcx,rdx
       je        near ptr M01_L07
       cmp       r8,20
       jae       short M01_L00
       cmp       r8,10
       jb        near ptr M01_L14
       jmp       near ptr M01_L09
M01_L00:
       xor       eax,eax
       add       r8,0FFFFFFFFFFFFFFE0
       je        short M01_L02
M01_L01:
       vmovupd   ymm0,[rcx+rax]
       vmovupd   ymm1,[rdx+rax]
       vpcmpeqb  ymm0,ymm0,ymm1
       vpmovmskb r9d,ymm0
       cmp       r9d,0FFFFFFFF
       jne       short M01_L08
       add       rax,20
       cmp       r8,rax
       ja        short M01_L01
M01_L02:
       vmovupd   ymm0,[rcx+r8]
       vmovupd   ymm1,[rdx+r8]
       vpcmpeqb  ymm0,ymm0,ymm1
       vpmovmskb ecx,ymm0
       cmp       ecx,0FFFFFFFF
       jne       short M01_L08
       jmp       short M01_L07
M01_L03:
       cmp       r8,4
       jae       short M01_L11
       xor       eax,eax
       mov       r9,r8
       and       r9,2
       je        short M01_L04
       movzx     eax,word ptr [rcx]
       movzx     r10d,word ptr [rdx]
       sub       eax,r10d
M01_L04:
       test      r8b,1
       jne       short M01_L06
M01_L05:
       test      eax,eax
       sete      al
       movzx     eax,al
       jmp       short M01_L12
M01_L06:
       movzx     r8d,byte ptr [rcx+r9]
       movzx     ecx,byte ptr [rdx+r9]
       sub       r8d,ecx
       or        r8d,eax
       mov       eax,r8d
       jmp       short M01_L05
M01_L07:
       mov       eax,1
       vzeroupper
       ret
M01_L08:
       xor       eax,eax
       vzeroupper
       ret
M01_L09:
       xor       eax,eax
       lea       r9,[r8-10]
       test      r9,r9
       jne       short M01_L13
M01_L10:
       vmovupd   xmm0,[rcx+r9]
       vmovupd   xmm1,[rdx+r9]
       vpcmpeqb  xmm0,xmm0,xmm1
       vpmovmskb r8d,xmm0
       cmp       r8d,0FFFF
       jne       short M01_L08
       jmp       short M01_L07
M01_L11:
       lea       rax,[r8-4]
       mov       r9d,[rcx]
       sub       r9d,[rdx]
       mov       ecx,[rcx+rax]
       sub       ecx,[rdx+rax]
       or        r9d,ecx
       sete      al
       movzx     eax,al
M01_L12:
       vzeroupper
       ret
M01_L13:
       vmovupd   xmm0,[rcx+rax]
       vmovupd   xmm1,[rdx+rax]
       vpcmpeqb  xmm0,xmm0,xmm1
       vpmovmskb r8d,xmm0
       cmp       r8d,0FFFF
       jne       short M01_L08
       add       rax,10
       cmp       r9,rax
       ja        short M01_L13
       jmp       short M01_L10
M01_L14:
       lea       rax,[r8-8]
       mov       r8,[rcx]
       sub       r8,[rdx]
       mov       rcx,[rcx+rax]
       sub       rcx,[rdx+rax]
       or        r8,rcx
       sete      al
       movzx     eax,al
       jmp       short M01_L12
; Total bytes of code 324
```

## .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2
```assembly
; DotNetPerf.Benchmarks.System.System_String_Equals.InstEqualsComp()
       push      rdi
       push      rsi
       sub       rsp,28
       mov       rsi,rcx
;             bool result = false;
;             ^^^^^^^^^^^^^^^^^^^^
       xor       edi,edi
;                 result = _values1[i].Equals(_values2[i], StringComparison.Ordinal);
;                 ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
M00_L00:
       mov       rcx,[rsi+8]
       cmp       edi,[rcx+8]
       jae       short M00_L01
       movsxd    rdx,edi
       mov       rcx,[rcx+rdx*8+10]
       mov       r8,[rsi+10]
       cmp       edi,[r8+8]
       jae       short M00_L01
       mov       rdx,[r8+rdx*8+10]
       mov       r8d,4
       cmp       [rcx],ecx
       call      System.String.Equals(System.String, System.StringComparison)
;             for (int i = 0; i < TotalItemsToTest; i++)
;                                                   ^^^
       inc       edi
       cmp       edi,1E
       jl        short M00_L00
       add       rsp,28
       pop       rsi
       pop       rdi
       ret
M00_L01:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 76
```
```assembly
; System.String.Equals(System.String, System.StringComparison)
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,28
       mov       rdi,rcx
       mov       rsi,rdx
       mov       ebx,r8d
M01_L00:
       cmp       rdi,rsi
       je        short M01_L03
       test      rsi,rsi
       je        near ptr M01_L05
       cmp       ebx,5
       jne       short M01_L04
       mov       eax,[rdi+8]
       cmp       eax,[rsi+8]
       je        short M01_L02
M01_L01:
       xor       eax,eax
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L02:
       mov       rcx,rdi
       mov       rdx,rsi
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       jmp       near ptr System.String.EqualsOrdinalIgnoreCaseNoLengthCheck(System.String, System.String)
M01_L03:
       cmp       ebx,5
       ja        near ptr M01_L08
       mov       eax,1
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L04:
       cmp       ebx,5
       ja        near ptr M01_L07
       mov       r8d,ebx
       lea       rcx,[7FF862698370]
       mov       ecx,[rcx+r8*4]
       lea       rdx,[M01_L00]
       add       rcx,rdx
       jmp       rcx
       mov       r8d,[rdi+8]
       cmp       r8d,[rsi+8]
       jne       short M01_L01
       lea       rcx,[rdi+0C]
       lea       rdx,[rsi+0C]
       mov       r8d,[rdi+8]
       add       r8d,r8d
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       jmp       near ptr System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       mov       r9,186B4AB1520
       mov       rcx,[r9]
       mov       r9d,ebx
       and       r9d,1
       mov       rdx,rdi
       mov       r8,rsi
       call      System.Globalization.CompareInfo.Compare(System.String, System.String, System.Globalization.CompareOptions)
       test      eax,eax
       sete      bpl
       movzx     ebp,bpl
       jmp       short M01_L06
M01_L05:
       cmp       ebx,5
       ja        short M01_L08
       jmp       near ptr M01_L01
M01_L06:
       movzx     eax,bpl
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L07:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       mov       ecx,0F32B
       mov       rdx,7FF862324000
       call      CORINFO_HELP_STRCNS
       mov       rcx,rax
       call      System.SR.GetResourceString(System.String)
       mov       rdi,rax
       mov       ecx,196A
       mov       rdx,7FF862324000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,rdi
       mov       rcx,rbx
       call      System.ArgumentException..ctor(System.String, System.String)
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
M01_L08:
       mov       ecx,18
       mov       edx,2A
       call      System.ThrowHelper.ThrowArgumentException(System.ExceptionResource, System.ExceptionArgument)
       int       3
       call      System.Globalization.CultureInfo.get_CurrentCulture()
       mov       rcx,rax
       mov       rax,[rax]
       mov       rax,[rax+48]
       call      qword ptr [rax+30]
       mov       rcx,rax
       mov       r9d,ebx
       and       r9d,1
       mov       rdx,rdi
       mov       r8,rsi
       cmp       [rcx],ecx
       call      System.Globalization.CompareInfo.Compare(System.String, System.String, System.Globalization.CompareOptions)
       test      eax,eax
       sete      bpl
       movzx     ebp,bpl
       jmp       near ptr M01_L06
; Total bytes of code 399
```

## .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2
```assembly
; DotNetPerf.Benchmarks.System.System_String_Equals.SpanSeqEquals()
       push      rdi
       push      rsi
       sub       rsp,28
       mov       rsi,rcx
;             bool result = false;
;             ^^^^^^^^^^^^^^^^^^^^
       xor       edi,edi
;                 result = _values1[i].AsSpan().SequenceEqual(_values2[i].AsSpan());
;                 ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
M00_L00:
       mov       r8,[rsi+8]
       cmp       edi,[r8+8]
       jae       short M00_L07
       movsxd    rcx,edi
       mov       r8,[r8+rcx*8+10]
       test      r8,r8
       jne       short M00_L01
       xor       edx,edx
       xor       eax,eax
       jmp       short M00_L02
M00_L01:
       lea       rdx,[r8+0C]
       mov       eax,[r8+8]
M00_L02:
       mov       r8,[rsi+10]
       cmp       edi,[r8+8]
       jae       short M00_L07
       mov       r8,[r8+rcx*8+10]
       test      r8,r8
       jne       short M00_L03
       xor       ecx,ecx
       xor       r9d,r9d
       jmp       short M00_L04
M00_L03:
       lea       rcx,[r8+0C]
       mov       r9d,[r8+8]
M00_L04:
       mov       [rsp+20],rcx
       cmp       eax,r9d
       jne       short M00_L05
       mov       r8d,eax
       add       r8,r8
       mov       rcx,rdx
       mov       rdx,[rsp+20]
       call      System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       jmp       short M00_L06
M00_L05:
       xor       eax,eax
;             for (int i = 0; i < TotalItemsToTest; i++)
;                                                   ^^^
M00_L06:
       inc       edi
       cmp       edi,1E
       jl        short M00_L00
       add       rsp,28
       pop       rsi
       pop       rdi
       ret
M00_L07:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 136
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       vzeroupper
       cmp       r8,8
       jb        short M01_L03
       cmp       rcx,rdx
       je        near ptr M01_L07
       cmp       r8,20
       jae       short M01_L00
       cmp       r8,10
       jb        near ptr M01_L14
       jmp       near ptr M01_L09
M01_L00:
       xor       eax,eax
       add       r8,0FFFFFFFFFFFFFFE0
       je        short M01_L02
M01_L01:
       vmovupd   ymm0,[rcx+rax]
       vmovupd   ymm1,[rdx+rax]
       vpcmpeqb  ymm0,ymm0,ymm1
       vpmovmskb r9d,ymm0
       cmp       r9d,0FFFFFFFF
       jne       short M01_L08
       add       rax,20
       cmp       r8,rax
       ja        short M01_L01
M01_L02:
       vmovupd   ymm0,[rcx+r8]
       vmovupd   ymm1,[rdx+r8]
       vpcmpeqb  ymm0,ymm0,ymm1
       vpmovmskb ecx,ymm0
       cmp       ecx,0FFFFFFFF
       jne       short M01_L08
       jmp       short M01_L07
M01_L03:
       cmp       r8,4
       jae       short M01_L11
       xor       eax,eax
       mov       r9,r8
       and       r9,2
       je        short M01_L04
       movzx     eax,word ptr [rcx]
       movzx     r10d,word ptr [rdx]
       sub       eax,r10d
M01_L04:
       test      r8b,1
       jne       short M01_L06
M01_L05:
       test      eax,eax
       sete      al
       movzx     eax,al
       jmp       short M01_L12
M01_L06:
       movzx     r8d,byte ptr [rcx+r9]
       movzx     ecx,byte ptr [rdx+r9]
       sub       r8d,ecx
       or        r8d,eax
       mov       eax,r8d
       jmp       short M01_L05
M01_L07:
       mov       eax,1
       vzeroupper
       ret
M01_L08:
       xor       eax,eax
       vzeroupper
       ret
M01_L09:
       xor       eax,eax
       lea       r9,[r8-10]
       test      r9,r9
       jne       short M01_L13
M01_L10:
       vmovupd   xmm0,[rcx+r9]
       vmovupd   xmm1,[rdx+r9]
       vpcmpeqb  xmm0,xmm0,xmm1
       vpmovmskb r8d,xmm0
       cmp       r8d,0FFFF
       jne       short M01_L08
       jmp       short M01_L07
M01_L11:
       lea       rax,[r8-4]
       mov       r9d,[rcx]
       sub       r9d,[rdx]
       mov       ecx,[rcx+rax]
       sub       ecx,[rdx+rax]
       or        r9d,ecx
       sete      al
       movzx     eax,al
M01_L12:
       vzeroupper
       ret
M01_L13:
       vmovupd   xmm0,[rcx+rax]
       vmovupd   xmm1,[rdx+rax]
       vpcmpeqb  xmm0,xmm0,xmm1
       vpmovmskb r8d,xmm0
       cmp       r8d,0FFFF
       jne       short M01_L08
       add       rax,10
       cmp       r9,rax
       ja        short M01_L13
       jmp       short M01_L10
M01_L14:
       lea       rax,[r8-8]
       mov       r8,[rcx]
       sub       r8,[rdx]
       mov       rcx,[rcx+rax]
       sub       rcx,[rdx+rax]
       or        r8,rcx
       sete      al
       movzx     eax,al
       jmp       short M01_L12
; Total bytes of code 324
```

## .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2
```assembly
; DotNetPerf.Benchmarks.System.System_String_Equals.StaticEquals()
       push      rdi
       push      rsi
       sub       rsp,28
       mov       rsi,rcx
;             bool result = false;
;             ^^^^^^^^^^^^^^^^^^^^
       xor       edi,edi
;                 result = string.Equals(_values1[i], _values2[i]);
;                 ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
M00_L00:
       mov       r8,[rsi+8]
       cmp       edi,[r8+8]
       jae       short M00_L05
       movsxd    rcx,edi
       mov       r8,[r8+rcx*8+10]
       mov       rdx,[rsi+10]
       cmp       edi,[rdx+8]
       jae       short M00_L05
       mov       rdx,[rdx+rcx*8+10]
       cmp       r8,rdx
       jne       short M00_L01
       mov       eax,1
       jmp       short M00_L04
M00_L01:
       test      r8,r8
       je        short M00_L02
       test      rdx,rdx
       je        short M00_L02
       mov       ecx,[r8+8]
       cmp       ecx,[rdx+8]
       je        short M00_L03
M00_L02:
       xor       eax,eax
       jmp       short M00_L04
M00_L03:
       add       r8,0C
       mov       [rsp+20],r8
       add       rdx,0C
       add       ecx,ecx
       mov       r8d,ecx
       mov       rcx,[rsp+20]
       call      System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       movzx     eax,al
;             for (int i = 0; i < TotalItemsToTest; i++)
;                                                   ^^^
M00_L04:
       inc       edi
       cmp       edi,1E
       jl        short M00_L00
       add       rsp,28
       pop       rsi
       pop       rdi
       ret
M00_L05:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 129
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       vzeroupper
       cmp       r8,8
       jb        short M01_L03
       cmp       rcx,rdx
       je        near ptr M01_L07
       cmp       r8,20
       jae       short M01_L00
       cmp       r8,10
       jb        near ptr M01_L14
       jmp       near ptr M01_L09
M01_L00:
       xor       eax,eax
       add       r8,0FFFFFFFFFFFFFFE0
       je        short M01_L02
M01_L01:
       vmovupd   ymm0,[rcx+rax]
       vmovupd   ymm1,[rdx+rax]
       vpcmpeqb  ymm0,ymm0,ymm1
       vpmovmskb r9d,ymm0
       cmp       r9d,0FFFFFFFF
       jne       short M01_L08
       add       rax,20
       cmp       r8,rax
       ja        short M01_L01
M01_L02:
       vmovupd   ymm0,[rcx+r8]
       vmovupd   ymm1,[rdx+r8]
       vpcmpeqb  ymm0,ymm0,ymm1
       vpmovmskb ecx,ymm0
       cmp       ecx,0FFFFFFFF
       jne       short M01_L08
       jmp       short M01_L07
M01_L03:
       cmp       r8,4
       jae       short M01_L11
       xor       eax,eax
       mov       r9,r8
       and       r9,2
       je        short M01_L04
       movzx     eax,word ptr [rcx]
       movzx     r10d,word ptr [rdx]
       sub       eax,r10d
M01_L04:
       test      r8b,1
       jne       short M01_L06
M01_L05:
       test      eax,eax
       sete      al
       movzx     eax,al
       jmp       short M01_L12
M01_L06:
       movzx     r8d,byte ptr [rcx+r9]
       movzx     ecx,byte ptr [rdx+r9]
       sub       r8d,ecx
       or        r8d,eax
       mov       eax,r8d
       jmp       short M01_L05
M01_L07:
       mov       eax,1
       vzeroupper
       ret
M01_L08:
       xor       eax,eax
       vzeroupper
       ret
M01_L09:
       xor       eax,eax
       lea       r9,[r8-10]
       test      r9,r9
       jne       short M01_L13
M01_L10:
       vmovupd   xmm0,[rcx+r9]
       vmovupd   xmm1,[rdx+r9]
       vpcmpeqb  xmm0,xmm0,xmm1
       vpmovmskb r8d,xmm0
       cmp       r8d,0FFFF
       jne       short M01_L08
       jmp       short M01_L07
M01_L11:
       lea       rax,[r8-4]
       mov       r9d,[rcx]
       sub       r9d,[rdx]
       mov       ecx,[rcx+rax]
       sub       ecx,[rdx+rax]
       or        r9d,ecx
       sete      al
       movzx     eax,al
M01_L12:
       vzeroupper
       ret
M01_L13:
       vmovupd   xmm0,[rcx+rax]
       vmovupd   xmm1,[rdx+rax]
       vpcmpeqb  xmm0,xmm0,xmm1
       vpmovmskb r8d,xmm0
       cmp       r8d,0FFFF
       jne       short M01_L08
       add       rax,10
       cmp       r9,rax
       ja        short M01_L13
       jmp       short M01_L10
M01_L14:
       lea       rax,[r8-8]
       mov       r8,[rcx]
       sub       r8,[rdx]
       mov       rcx,[rcx+rax]
       sub       rcx,[rdx+rax]
       or        r8,rcx
       sete      al
       movzx     eax,al
       jmp       short M01_L12
; Total bytes of code 324
```

## .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2
```assembly
; DotNetPerf.Benchmarks.System.System_String_Equals.StaticEqualsComp()
       push      rdi
       push      rsi
       sub       rsp,28
       mov       rsi,rcx
;             bool result = false;
;             ^^^^^^^^^^^^^^^^^^^^
       xor       edi,edi
;                 result = string.Equals(_values1[i], _values2[i], StringComparison.Ordinal);
;                 ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
M00_L00:
       mov       rcx,[rsi+8]
       cmp       edi,[rcx+8]
       jae       short M00_L01
       movsxd    rdx,edi
       mov       rcx,[rcx+rdx*8+10]
       mov       r8,[rsi+10]
       cmp       edi,[r8+8]
       jae       short M00_L01
       mov       rdx,[r8+rdx*8+10]
       mov       r8d,4
       call      System.String.Equals(System.String, System.String, System.StringComparison)
;             for (int i = 0; i < TotalItemsToTest; i++)
;                                                   ^^^
       inc       edi
       cmp       edi,1E
       jl        short M00_L00
       add       rsp,28
       pop       rsi
       pop       rdi
       ret
M00_L01:
       call      CORINFO_HELP_RNGCHKFAIL
       int       3
; Total bytes of code 74
```
```assembly
; System.String.Equals(System.String, System.String, System.StringComparison)
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,28
       mov       rsi,rcx
       mov       rdi,rdx
       mov       ebx,r8d
M01_L00:
       cmp       rsi,rdi
       je        short M01_L02
       test      rsi,rsi
       je        near ptr M01_L05
       test      rdi,rdi
       je        near ptr M01_L05
       cmp       ebx,5
       jne       short M01_L04
       mov       eax,[rsi+8]
       cmp       eax,[rdi+8]
       je        short M01_L03
M01_L01:
       xor       eax,eax
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L02:
       cmp       ebx,5
       ja        near ptr M01_L08
       mov       eax,1
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L03:
       mov       rcx,rsi
       mov       rdx,rdi
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       jmp       near ptr System.String.EqualsOrdinalIgnoreCaseNoLengthCheck(System.String, System.String)
M01_L04:
       cmp       ebx,5
       ja        short M01_L07
       mov       r8d,ebx
       lea       rcx,[7FF8626A83B8]
       mov       ecx,[rcx+r8*4]
       lea       rdx,[M01_L00]
       add       rcx,rdx
       jmp       rcx
       mov       r8d,[rsi+8]
       cmp       r8d,[rdi+8]
       jne       short M01_L01
       lea       rcx,[rsi+0C]
       lea       rdx,[rdi+0C]
       mov       r8d,[rsi+8]
       add       r8d,r8d
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       jmp       near ptr System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M01_L05:
       cmp       ebx,5
       ja        short M01_L08
       jmp       near ptr M01_L01
M01_L06:
       movzx     eax,bpl
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L07:
       mov       rcx,offset MT_System.ArgumentException
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       mov       ecx,0F32B
       mov       rdx,7FF862334000
       call      CORINFO_HELP_STRCNS
       mov       rcx,rax
       call      System.SR.GetResourceString(System.String)
       mov       rsi,rax
       mov       ecx,196A
       mov       rdx,7FF862334000
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,rsi
       mov       rcx,rbx
       call      System.ArgumentException..ctor(System.String, System.String)
       mov       rcx,rbx
       call      CORINFO_HELP_THROW
M01_L08:
       mov       ecx,18
       mov       edx,2A
       call      System.ThrowHelper.ThrowArgumentException(System.ExceptionResource, System.ExceptionArgument)
       int       3
       call      System.Globalization.CultureInfo.get_CurrentCulture()
       mov       rcx,rax
       mov       rax,[rax]
       mov       rax,[rax+48]
       call      qword ptr [rax+30]
       mov       rcx,rax
       mov       r9d,ebx
       and       r9d,1
       mov       rdx,rsi
       mov       r8,rdi
       cmp       [rcx],ecx
       call      System.Globalization.CompareInfo.Compare(System.String, System.String, System.Globalization.CompareOptions)
       test      eax,eax
       sete      bpl
       movzx     ebp,bpl
       jmp       near ptr M01_L06
       mov       r9,1F1EC201520
       mov       rcx,[r9]
       mov       r9d,ebx
       and       r9d,1
       mov       rdx,rsi
       mov       r8,rdi
       call      System.Globalization.CompareInfo.Compare(System.String, System.String, System.Globalization.CompareOptions)
       test      eax,eax
       sete      bpl
       movzx     ebp,bpl
       jmp       near ptr M01_L06
; Total bytes of code 407
```


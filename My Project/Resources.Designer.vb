﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("ExperimentalPlayer.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to {\rtf1\ansi\ansicpg1252\deff0\deflang1035{\fonttbl{\f0\fnil\fcharset0 Arial;}{\f1\fnil\fcharset0 Microsoft Sans Serif;}{\f2\fnil Microsoft Sans Serif;}}
        '''\viewkind4\uc1\pard\ul\fs53 Welcome to using JPlayer!\fs41\par
        '''\par
        '''\f1\fs48 Info about the main screen\fs26\par
        '''\ulnone\fs20\par
        '''\ul\fs41 Upper part:\ulnone\fs20\par
        '''\par
        '''- Song info (current position, total duration, name)\par
        '''- Trackbar for the purpose of skipping to a certain spot (it also shows the current position)\par
        '''- Volume adjustment bar [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property jplayer_help() As String
            Get
                Return ResourceManager.GetString("jplayer_help", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to - context menu - OK!
        '''- shuffle - OK!
        '''- Siirto soitettavan kappaleen läpi-bugi - OK!
        '''- läjä muita bugeja taas hoidettu..., siis: OK!
        '''
        '''- Ohje -OK!, pitää päivittää kun ominaisuuksia lisätään
        '''- bugi: jos poistaa biisin listalta soitettavan biisin ollessa alapuolella, se hyppää yhden biisin, yli. Lisäksi, jos shuffle on päällä, saattaa soittaa saman biisin. Korjaus: currentPlaying:n päivitys poiston yhteydessä. KORJATTU!
        '''
        '''- biisin vaihtuessa tooltip, uudesta biisistä - OK!
        '''- Form1.Text:n vaihto muotoon [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property JPlayer_todo() As String
            Get
                Return ResourceManager.GetString("JPlayer_todo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property jplayerlogo() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("jplayerlogo", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
    End Module
End Namespace

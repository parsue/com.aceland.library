﻿# Changelog

All notable changes to this project will be documented in this file.

## [Unreleased]

---

## [1.0.20] - 2025-04-02
### Added
- [Attribute] ReadOnlyField - showing the field as non-editable in Inspector window

## [1.0.18] - 2025-03-14
### Modified
- [Extension.int] remove clamp function from Remap

## [1.0.17] - 2025-03-04
### Modified
- [Json] amended namespace of JsonConverter

## [1.0.16] - 2025-03-04
### Added
- [Serialization Surrogate] more Unity data types
- [Json] JsonConverters for more Unity data types

## [1.0.15] - 2025-03-04
### Added
- [Serialization Surrogate] Bounds and Matrix4x4
- [Json] JsonConverters for Unity data types, Json Extensions default using all JsonConverters 
### Modified
- [Utils] Helper Function GetBinaryFormatter() return IFormatter now

## [1.0.14] - 2025-02-23
### Added
- [Serialization Surrogate] Vector4 Serialization Surrogate

## [1.0.13] - 2025-02-22
### Modify
- [Extensions] more functions

## [1.0.12] - 2025-02-14
### Modify
- improve codes to solve performance and memory allocation issues

## [1.0.11] - 2025-02-04
### Modify
- [Mono] use SetParent() in Singleton.

## [1.0.10] - 2025-01-25
### Modify
- [Mono] Make Singleton Instance public.
- [BuildLeveling] Separate files by classes.

## [1.0.9] - 2025-01-14
### Fix
- [Extension] Transform.DestroyAllChildren will loop to dead. It's cause Editor is not updating the Transform.childCount on child destroyed.

## [1.0.8] - 2025-01-13
### Add
- [Extension] Texture2D.Resize(int targetWidth, int targetHeight)
- [Extension] Texture2D.Resize(int maxSize)
- [Extension] Texture2D.CropAndResizeToSquare(int squareSize)
- [Extension] Color[].ResizePixels(int originalWidth, int originalHeight, int newWidth, int newHeight)

## [1.0.7] - 2025-01-3
### Modify
- [Json] Add option to use withTypeName settings

## [1.0.6] - 2024-11-26
### Modify
- [Editor] Undo functional for Project Settings

## [1.0.4] - 2024-11-24
First public release. If you have an older version, please update or re-install.   
For detail please visit and bookmark our [GitBook](https://aceland-workshop.gitbook.io/aceland-unity-packages/)

# Changelog

All notable changes to this project will be documented in this file.

## [Unreleased]

---

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

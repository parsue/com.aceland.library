# Changelog

All notable changes to this project will be documented in this file.

---

## [2.2.3] - 2026-06-23
### Added
- [ALib] system and temp roots are separated by editor and build, defaultly true 

## [2.2.2] - 2026-06-17
### Fixed
- [Audio Previewer] Unity 6.5 InstanceId issue 

## [2.2.1] - 2025-12-21
### Removed
- [Disposal] separate to independent package
- [Geo Location] separate to independent package
- [Model] separate to independent package
- [Singleton] separate to independent package
- [Mono] removed due to not useful
- [Extensions] separate partal contents to independent package
- [Utils] separate partal contents to independent package

## [2.2.0] - 2025-12-20
### Added
- [Dependency] AceLand.ProjectSetting
### Removed
- [Data Tools] separate to independent package
- [Easing Curve] separate to independent package
- [Metric] separate to independent package
- [Optional] separate to independent package
- [ProjectSetting] separate to independent package, including Build Level

---

## [2.1.4] - 2025-12-18
### Fixed
- [ALib] Cache SystemRoot

## [2.1.3] - 2025-12-16
### Fixed
- [ALib] Update SystemRoot on Initialization

## [2.1.1] - 2025-12-13
### Added
- all meta files

## [2.1.0] - 2025-12-13
### Modified
- [Editor] handle obsolute function on 6000.3 or newer
### Removed
- all meta files

## [2.0.11] - 2025-12-06
### Modified
- [package.json] add doc links

## [2.0.10] 2025-11-30
### Removed
- [Kalman Filter] become independent package.

## [2.0.9] 2025-11-28
### Modified
- [Kalman Filter] documents updated
- [Kalman Filter] set internal to concret class, open only interface
- [Kalman Filter] internal structure

## [2.0.8] 2025-11-13
### Added
- [Metric] strong type for Length and Area for metric units
- [GeoLocation] string type for Wgs84Location with Latitude and Longitude

## [2.0.7] 2025-11-08
### Modified
- [csv] fix csv reader ignore first line when csv contains no header

## [2.0.6] 2025-11-08
### Modified
- [Json] fix GradientConverter reference loop handling issue
- [Json] promised usage for converters, please view document

## [2.0.5] 2025-10-18
### Removed
- [Helper] UI functions - implement to Input Package

## [2.0.4] 2025-10-05
### Added
- [ALib] API to Utils Object
- [Project Settings] Unity Application locations
- [Project Settings] temp locations with own SystemRoot
### Modified
- [Utils] switch to internal object, create on first call
- Platform becomes ALib.Platform
- Helper becomes ALib.Helper
- [Json] Extension with data models
### Removed
- [Utils] to be internal functions, us ALib to access
- [Json] Json Async task move to Task Utils

## [2.0.3] - 2025-09-23
### Added
- [Json] converters for native types
- [Models] PathData for safe path data
- [Models] CsvData for cache of csv contents
### Modified
- [CSV] Extension with data models

## [2.0.2] - 2025-09-21
- [Dependency] request ZLinq installed from NuGet
- optimize code with ZLinq
- add AMVR project settings page
- [Project Settings] add applicatoin root and temp root options
- [Bootstrapper] auto create application root folder if option enabled
- [Easing Curve] curves by math calculation
- [Attribute] fix ReadonlyField incorrect line height of property
- [DisposableObject] tag properties as Json Ignore

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

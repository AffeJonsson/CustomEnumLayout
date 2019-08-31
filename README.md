# CustomEnumLayout

Contains utility methods for drawing Popup fields with a given array of enums, or all enums excluding a set of value.

## Examples

```cs
// Displays a popup with three values; A, B and C.
target.MyEnumValue = EditorGUILayoutExtended.PopupWithSpecificValues(target.MyEnumValue, MyEnum.A, MyEnum.B, MyEnum.C);
```

```cs
// Displays a popup with all values in the enum, except for X and Z.
target.MyEnumValue = EditorGUILayoutExtended.PopupWithoutSpecificValues(target.MyEnumValue, MyEnum.X, MyEnum.Z);
```

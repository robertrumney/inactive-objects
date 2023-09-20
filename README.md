# Inactive Static Objects Finder for Unity

This tool provides an efficient way to identify and list inactive static objects within your active Unity scene. Whether you are an artist, level designer, or developer, keeping track of static objects that are not active in your scene hierarchy can help optimize and clean up your projects. 

## Features

1. **List Inactive Static Objects**: Quickly identify objects that are static but not active in the hierarchy.
2. **Ignore Specific Objects**: Define specific names or transforms to exclude from the search, giving you the flexibility to focus on what matters.
3. **Intuitive UI**: Easily accessible from the Unity editor window and comes with a user-friendly interface.

## Installation

1. Clone or download this repository.
2. Move the `InactiveStaticObjectsWindow.cs` script into a folder named `Editor` within your Unity project. Unity executes scripts in an Editor folder only in the Unity Editor and strips them from builds.

**Note**: It's essential to place this script in an `Editor` folder so that it doesn't get included in the final build, as it's meant for editor-time use only.

## Usage

1. Open Unity and go to `Window` in the top menu.
2. Select `Inactive Static Objects` from the dropdown.
3. Use the tool's interface to identify inactive static objects and set your ignore preferences.

## Contributing

Feel free to fork this project and submit pull requests or raise issues if you find any bugs or have suggestions for improvements.

## License

[MIT License](LICENSE.md)

---
I Hope this tool proves beneficial in streamlining your large-map Unity project workflows!

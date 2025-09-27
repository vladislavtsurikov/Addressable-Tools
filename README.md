# Addressable Tools

A set of tools for extending and automating workflows with Unity Addressables. The repository includes three modules:

- `AddressableLoaderSystem` – an extensible runtime framework for loading resources via Addressables.
- `AddressablesEditorTools` – a set of editor utilities for simplifying AddressableAssetSettings management.
- `AddressableGroupGenerator` – automatic group generation and asset structuring.

---

## AddressableLoaderSystem (Main Module)

`AddressableLoaderSystem` is a modular framework that provides centralized loading and unloading of Addressable assets based on filters and rules.

### Key Features:

- Automatic resource loading using attribute-based filtering;
- Automatic unloading when the loader is destroyed;
- Integration with DI containers (Zenject, VContainer);
- Automatic registration and injection of configuration assets;
- Reflection-based loading of `AssetReference` fields from `ScriptableObject`;
- Utilities and extensions for tracking asset handles and groups;
- Debug test scene with sample configurations, logs, and scene switching.

---

### How It Works

The system relies on attribute-based filtering applied to each `ResourceLoader` class. These attributes define which Addressable labels should be resolved and loaded.

#### Attributes
- `FilterAttribute` – defines the general context filter;
- `SceneFilterAttribute` – filters resources by scene;
- `GlobalFilterAttribute` – filters global shared assets;
- `IgnoreResourceAutoload` – disables automatic loading.

All attributes are resolved into label lists using `AddressableLabelMapAsset` and used to query Addressables.

---

#### ResourceLoader

Each `ResourceLoader`:

- Registers itself automatically using `ResourceLoaderManager` or `StandaloneResourceLoaderRegistrar`;
- Loads assets by resolving labels from its assigned attributes;
- Unloads assets when destroyed (`Dispose` or `OnDestroy`);
- Can be used manually to load/unload specific resources at runtime.

---

#### Zenject and DI

Zenject and VContainer integration is supported via:

- `BindableResourceLoader` – loads assets and automatically binds them into the DI container;
- `BindableResourceLoaderRegistrar` – scans and registers all loaders and their results during scene initialization;
- Enables `Inject` in any `MonoBehaviour`, `Installer`, or `ScriptableObject` without manual binding logic.

---

#### AssetReference Loading via Reflection

The `AssetReferenceReflectionLoader` component:

- Recursively scans all fields with `AssetReference`, including nested `ScriptableObject`, collections, and dictionaries;
- Automatically loads all found references;
- Eliminates the need to manually specify individual asset loading logic.

---

#### Logging and Debugging

- Built-in logging at all stages: loading, unloading, and DI binding;
- Clearly displays what is loaded, from where, and when it is released;
- Used actively in the test scene (in the `Tests` folder).

---

#### Test Scene

A standalone test scene is included in the project:

- Acts as an alternative to unit tests;
- Covers edge cases such as:
    - Loading from `Dictionary` fields;
    - Nested configuration objects;
    - Reuse of already loaded configs;
    - Cross-scene asset management.
- Verifies DI injection behavior;
- Logs every step of the process;
- Includes an IMGUI-based scene switcher (`TestSceneSwitcherIMGUI`) for visual validation.

---

## AddressablesEditorTools

A set of editor utilities that streamline manual Addressable management:

- Quickly assign or remove labels in batch;
- Mass update of asset-label mappings;
- Visual inspection and refresh of Addressable entries;
- Useful for large teams and large-scale asset operations.

---

## AddressableGroupGenerator

A tool for automatically generating Addressable groups and assigning labels based on project structure:

- Grouping by folder hierarchy;
- Grouping by asset type or file naming;
- Automatic label assignment rules;
- Useful for initial Addressables setup or ongoing project maintenance.

---

## Repository Structure

```
Assets/VladislavTsurikov/
│
├── AddressableLoaderSystem/       # Main framework for runtime resource loading
├── AddressablesEditorTools/      # Editor utilities for Addressables
└── AddressableGroupGenerator/    # Automated group and label assignment
```

---

## Dependencies

- Unity 2022.3
- Addressables
- Zenject

---

## License

MIT License
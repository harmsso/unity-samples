Talidu Dependency Diagram

```mermaid
graph TD;
    UI-->GameEvents;
    GameEvents-->PlayerData;
    Web-->PlayerData;
    Web-->EventSystem;
    Web-->Localization;
    RewardSystem-->EventSystem;
```

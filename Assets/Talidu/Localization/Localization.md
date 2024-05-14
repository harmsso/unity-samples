---
uid: Localization
summary: Contains everything related to localization.
---
 ### Localization

This localization system was designed to support multiple languages in an an app developed for primary school pupils to learn correct spelling.
Based on the children's language the correct audios and images must be loaded from an file server.

In addition to that every text in the app must be localizable, too.

The reasons behind the separation between text and asset localization are:

- not every application/game needs localized assets
- in this specific case the assets must be loaded from an server
- the text localization system is for local app text e.g. "Start Game", "Settings" and must not be replaced or edited multiple times
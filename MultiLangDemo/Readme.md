# MultiLangDemo — Localization Overview (Razor Pages, .NET 8)

This document lists localization scenarios included or planned for the project. Prioritized for a Razor Pages project targeting .NET 8.

| #  | Localization Type                 | Purpose / Notes                                  | Checklist |
|----|-----------------------------------|--------------------------------------------------|-----------|
| 1  | View Localization                 | Razor Views translate karna                      | - [x] View uses `IViewLocalizer` / `IHtmlLocalizer` in `Views/Home/Login.cshtml` |
| 2  | Controller Localization           | Backend/controller messages                      | - [ ] Inject `IStringLocalizer` into controllers/page models |
| 3  | Shared Resource Localization      | Common reusable translations                     | - [x] `Resources/SharedResource.en.resx` and `SharedResource.hi.resx` exist |
| 4  | Validation Localization           | Validation errors translate karna                | - [ ] Resource keys exist (`EmailRequired`, `PasswordRequired`, etc.) — DataAnnotations resource binding not yet configured |
| 5  | Model Localization                | Labels/display names localize                    | - [ ] `Display` attributes present on `UserModel` but not bound to a `ResourceType` |
| 6  | Enum Localization                 | Enum values translate karna                      | - [x] Enum values provided in resources and used in view via `SharedLocalizer` (`Active`, `Pending`, `Blocked`) |
| 7  | DataAnnotations Localization      | Validation attributes localize                   | - [ ] Use `ErrorMessageResourceType` / resource keys not yet configured for automatic lookup |
| 8  | Layout Localization               | Navbar/footer/shared layout                      | - [ ] Localize `_Layout.cshtml` shared UI |
| 9  | Partial View Localization         | Reusable partial components                      | - [ ] Localize partial views and view components |
| 10 | JavaScript Localization           | Alerts/toasts/frontend messages                  | - [ ] Expose translations to JS (JSON endpoint or inline) |
| 11 | API Localization                  | Multilingual API responses                       | - [ ] Return localized API errors/messages based on culture |
| 12 | JSON Localization                 | JSON-based translation storage                   | - [ ] Add JSON localization provider/files |
| 13 | Database Localization             | Dynamic DB-driven translations                   | - [ ] Implement DB-backed localization provider |
| 14 | Cookie Localization               | Persist language automatically                   | - [ ] Configure cookie request culture provider |
| 15 | Route Localization                | Language inside URL routes                       | - [ ] Add localized routing for routes/areas |
| 16 | Query String Localization         | `?culture=hi` style                              | - [x] Login form uses `asp-route-culture="@Context.Request.Query[\"culture\"]"` to preserve/forward culture |
| 17 | Session Localization              | Session-based language                           | - [ ] Store and read culture from session |
| 18 | Middleware Localization           | Request culture pipeline                         | - [ ] Register `RequestLocalization` middleware (check `Program.cs`) |
| 19 | Dynamic Runtime Localization      | Change translations without restart              | - [ ] Support reloadable resource provider |
| 20 | AI Localization                   | AI-generated translations                        | - [ ] Integrate translation API for suggestions/auto-translate |

Notes:
- Shared resources are present at `Resources/SharedResource.en.resx` and `Resources/SharedResource.hi.resx`.
- Implemented items (checked): View localization in `Views/Home/Login.cshtml`, Shared Resource files, Enum translations used in the view, and Query String culture forwarding in the login form.
- Suggested next steps to fully enable DataAnnotations/model localization:
  - Update your model attributes to use `ErrorMessageResourceName` and `ErrorMessageResourceType` or configure `DataAnnotationLocalizerProvider`.
  - Ensure `RequestLocalization` middleware is configured in `Program.cs` and add `AddLocalization()` / `AddViewLocalization()` in `Program.cs`.


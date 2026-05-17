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

  Next Day Topics 
- Layout localization (navbar/footer)
- Partial view localization
- Middleware localization
- DataAnnotations localization (validation messages)

After that Next day Plan 
- Route localization
- Session localization
- Json localization

After that Next day Plan
- Database localization
- Dynamic runtime localization
- AI localization
Topics already covered:
-  View Localization
- Controller Localization
- Shared Resource Localization
- Validation Localization
- Model Localization
- Enum Localization
- JavaScript Localization
- API Localization
- Cookie Localization
- Query String Localization
- Layout Localization
- Partial View Localization
- DataAnnotations Localization
-  Route Localization
-  JSON Localization
-  Database Localization
Topics to be Covered in Future
8. Dynamic Runtime Localization
9. AI Localization


How Middleware Localization Pipeline Works:
1. Request comes in with a culture (from cookie, query string, etc.)
1. `RequestLocalizationMiddleware` reads the culture and sets `Thread.CurrentThread.CurrentCulture` and `CurrentUICulture`
1. Controllers, views, and other components use the current culture to look up translations from resource files or providers
1. Responses are generated with localized content based on the current culture
1. If the culture changes (e.g., user selects a different language), the middleware updates the culture for subsequent requests, allowing dynamic localization without restarting the app.
1. This pipeline ensures that all parts of the application can access the correct localized resources based on the user's language preferences.


Cookies Localization :
	Cookie
	↓
	Stores selected language
	↓
	Middleware reads cookie
	↓
	Culture set

ROUTE LOCALIZATION SYSTEM
URL
↓
/hi/Home/Login
↓
Middleware reads route
↓
Culture set


Cookies Localization 
| #  | Aspects                | Cookies Localization                                 | Route Localization |
|----|-----------------------------------|--------------------------------------------------|-----------|
| 1  | Visibility                | Hidden in cookie                                   | Visible in URL |
| 2  | User Experience           | Transparent to user, persists across sessions       | Clear language indication in URL |
| 3  | SEO Impact                | No direct SEO benefit                               | Can improve SEO with language-specific URLs |
| 4  | Implementation Complexity | Relatively simple to implement                     | More complex, requires route configuration |
| 5  | Language Persistence      | Persists across sessions until cookie expires       | Only persists for the duration of the URL |


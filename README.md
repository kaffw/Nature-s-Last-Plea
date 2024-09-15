# Git Commit Message Guideline

## Structure
Each commit message should follow this structure:

```
<type>(<scope>): <subject>
```

- **type**: Type of change (e.g., Add, Update, Delete, Bugfix)
- **scope**: The scope of the change (e.g., feature, file, module)
- **subject**: A brief description of the change (imperative, present tense)

## Types and Use Cases

| Type    | Use Case                                                        | Example                                    |
|---------|------------------------------------------------------------------|--------------------------------------------|
| **Add** | When adding new features, files, or dependencies.               | `Add(feature): Implement user login functionality` |
| **Update** | When making changes to existing code, features, or dependencies without removing or adding new elements. | `Update(module): Refactor authentication logic` |
| **Delete** | When removing features, files, or dependencies.               | `Delete(file): Remove obsolete configuration files` |
| **Bugfix** | When fixing bugs or issues in the codebase.                    | `Bugfix(api): Fix user authentication issue` |

## Best Practices
- **Keep it Short**: Limit the subject line to 50 characters.
- **Capitalize Subject**: Start the subject with a capital letter.
- **Use Imperative Mood**: E.g., "Fix" instead of "Fixed" or "Fixes".
- **Provide Context**: If necessary, add more details in the body of the commit message.

## Examples

1. **Add**:
    ```
    Add(database): Create initial schema for user management
    ```

2. **Update**:
    ```
    Update(UI): Improve button styling on login page
    ```

3. **Delete**:
    ```
    Delete(test): Remove redundant test cases
    ```

4. **Bugfix**:
    ```
    Bugfix(cache): Resolve cache invalidation issue
    ```

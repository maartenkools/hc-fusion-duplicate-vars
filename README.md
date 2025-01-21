# HotChocolate Fusion Bug
This repository demonstrates a bug in HotChocolate Fusion in which a variable name is included twice in the execution plan, causing an error

# Usage
* Start both the Server and Gateway projects
* Navigate to http://localhost:2222/graphql
* Enter the following query:
```graphql
query getItems($groupId: String! = "groupId") {
  items(groupId: $groupId) {
    values(groupId: $groupId)
  }
}
```

The response is as following:
```json
{
  "errors": [
    {
      "message": "Cannot return null for non-nullable field.",
      "locations": [
        {
          "line": 2,
          "column": 3
        }
      ],
      "path": [
        "items"
      ],
      "extensions": {
        "code": "HC0018"
      }
    },
    {
      "message": "An item with the same key has already been added. Key: groupId",
      "extensions": {
        "code": "HC0012"
      }
    }
  ]
}
```

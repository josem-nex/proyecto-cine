# Buber Partner API

- [Partner API](#buber-Partner-api)
  - [Create Partner](#create-Partner)
    - [Create Partner Request](#create-Partner-request)
    - [Create Partner Response](#create-Partner-response)
  - [Get Partner](#get-Partner)
    - [Get Partner Request](#get-Partner-request)
    - [Get Partner Response](#get-Partner-response)
  - [Update Partner](#update-Partner)
    - [Update Partner Request](#update-Partner-request)
    - [Update Partner Response](#update-Partner-response)
  - [Delete Partner](#delete-Partner)
    - [Delete Partner Request](#delete-Partner-request)
    - [Delete Partner Response](#delete-Partner-response)

## Create Partner

### Create Partner Request

```js
POST {{host}}/auth/register
```

```json
{
  "firstname": "Laura Maria",
  "lastname": "Ramona",
  "email": "lmariar@gmail.com",
  "ci": "02101576475",
  "address": "Calle 1 #123",
  "phonenumber": "787-123-1234",
  "password": "123mn213"
}
```

### Create Partner Response

```js
201 Created
```

```yml
Location: {{host}}/Partners/{{id}}
```

```json
{
  "id": "guid123-1234-3123-1234-234bgf23fd",
  "firstname": "Jose Miguel",
  "lastname": "Zayas Pérez",
  "email": "nex25k@gmail.com",
  "points": 0,
  "token": "ewwrw...gfdg"
}
```

## Get Partner

### Get Partner Request

```js
GET /Partners/{{id}}
```

### Get Partner Response

```js
200 Ok
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Vegan Sunshine",
  "description": "Vegan everything! Join us for a healthy Partner..",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "lastModifiedDateTime": "2022-04-06T12:00:00",
  "savory": ["Oatmeal", "Avocado Toast", "Omelette", "Salad"],
  "Sweet": ["Cookie"]
}
```

## Update Partner

### Update Partner Request

```js
PUT /Partners/{{id}}
```

```json
{
  "name": "Vegan Sunshine",
  "description": "Vegan everything! Join us for a healthy Partner..",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "savory": ["Oatmeal", "Avocado Toast", "Omelette", "Salad"],
  "Sweet": ["Cookie"]
}
```

### Update Partner Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Partners/{{id}}
```

## Delete Partner

### Delete Partner Request

```js
DELETE /Partners/{{id}}
```

### Delete Partner Response

```js
204 No Content
```

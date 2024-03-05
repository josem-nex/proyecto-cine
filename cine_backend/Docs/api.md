# Buber socio API

- [Socio API](#buber-socio-api)
  - [Create socio](#create-socio)
    - [Create socio Request](#create-socio-request)
    - [Create socio Response](#create-socio-response)
  - [Get socio](#get-socio)
    - [Get socio Request](#get-socio-request)
    - [Get socio Response](#get-socio-response)
  - [Update socio](#update-socio)
    - [Update socio Request](#update-socio-request)
    - [Update socio Response](#update-socio-response)
  - [Delete socio](#delete-socio)
    - [Delete socio Request](#delete-socio-request)
    - [Delete socio Response](#delete-socio-response)

## Create socio

### Create socio Request

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

### Create socio Response

```js
201 Created
```

```yml
Location: {{host}}/socios/{{id}}
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

## Get socio

### Get socio Request

```js
GET /socios/{{id}}
```

### Get socio Response

```js
200 Ok
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Vegan Sunshine",
  "description": "Vegan everything! Join us for a healthy socio..",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "lastModifiedDateTime": "2022-04-06T12:00:00",
  "savory": ["Oatmeal", "Avocado Toast", "Omelette", "Salad"],
  "Sweet": ["Cookie"]
}
```

## Update socio

### Update socio Request

```js
PUT /socios/{{id}}
```

```json
{
  "name": "Vegan Sunshine",
  "description": "Vegan everything! Join us for a healthy socio..",
  "startDateTime": "2022-04-08T08:00:00",
  "endDateTime": "2022-04-08T11:00:00",
  "savory": ["Oatmeal", "Avocado Toast", "Omelette", "Salad"],
  "Sweet": ["Cookie"]
}
```

### Update socio Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/socios/{{id}}
```

## Delete socio

### Delete socio Request

```js
DELETE /socios/{{id}}
```

### Delete socio Response

```js
204 No Content
```

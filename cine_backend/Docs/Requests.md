# Requests

## Errors

Los errores se encuentran en Domain/Errors/

```json
{
  "type": "",
  "title": "",
  "status": 409,
  "detail": "",
  "traceId": "",
  "errorCodes": []
}
```

## Partner

### Register

#### Request

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

#### Response

```json
{
  "id": "1250bd0e-1256-4fb7-8729-4871c5066776",
  "firstName": "Laura Maria",
  "lastName": "Ramona",
  "email": "lmariar@gmail.com",
  "ci": "02101576475",
  "address": "Calle 1 #123",
  "phoneNumber": "787-123-1234",
  "points": 0,
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjUwYmQwZS0xMjU2LTRmYjctODcyOS00ODcxYzUwNjY3NzYiLCJnaXZlbl9uYW1lIjoiTGF1cmEgTWFyaWEiLCJmYW1pbHlfbmFtZSI6IlJhbW9uYSIsImp0aSI6ImMyZjc4ZDJhLTgwY2YtNGQ2Yy1hM2FmLTNmZWNlMjhjODUzOSIsImV4cCI6MTcxMTEyODAwOCwiaXNzIjoiQ2luZSIsImF1ZCI6IkNpbmUifQ.AN80s_ALaKXKo2OUDrr94seVbGVoPI5ytDvU_fJITvc"
}
```

### Login

#### Request

```json
{
  "email": "lmariar@gmail.com",
  "password": "123mn213"
}
```

#### Response

```json
{
  "id": "1250bd0e-1256-4fb7-8729-4871c5066776",
  "firstName": "Laura Maria",
  "lastName": "Ramona",
  "email": "lmariar@gmail.com",
  "ci": "02101576475",
  "address": "Calle 1 #123",
  "phoneNumber": "787-123-1234",
  "points": 0,
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjUwYmQwZS0xMjU2LTRmYjctODcyOS00ODcxYzUwNjY3NzYiLCJnaXZlbl9uYW1lIjoiTGF1cmEgTWFyaWEiLCJmYW1pbHlfbmFtZSI6IlJhbW9uYSIsImp0aSI6ImY0NDYyNjcwLWE4ZmUtNDI0Zi04M2Y0LTE4YWNjNDFiYTFjMSIsImV4cCI6MTcxMTEyODIzOCwiaXNzIjoiQ2luZSIsImF1ZCI6IkNpbmUifQ.AmboY-2PVTGK5wDJw2uPCDg3b0hcbZS7-MBPzIYMqU4"
}
```

### Update

#### Request

```json
{
  "id": "1250bd0e-1256-4fb7-8729-4871c5066776",
  "firstname": "Laura Maria editada",
  "lastname": "Ramona editada",
  "email": "lmariar@gmail.com",
  "ci": "02101576475",
  "address": "Calle 1 #123",
  "phonenumber": "787-123-1234",
  "password": "123mn213"
}
```

#### Response

```json
{
  "id": "1250bd0e-1256-4fb7-8729-4871c5066776",
  "firstName": "Laura Maria editada",
  "lastName": "Ramona",
  "email": "lmariar@gmail.com",
  "ci": "02101576475",
  "address": "Calle 1 #123",
  "phoneNumber": "787-123-1234",
  "points": 0,
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjUwYmQwZS0xMjU2LTRmYjctODcyOS00ODcxYzUwNjY3NzYiLCJnaXZlbl9uYW1lIjoiTGF1cmEgTWFyaWEgZWRpdGFkYSIsImZhbWlseV9uYW1lIjoiUmFtb25hIiwianRpIjoiNzI2ZGIxMjctZDIyYy00NjYwLWJjNmYtYjI1NzFjNGQzZjYxIiwiZXhwIjoxNzExMTI4NTc1LCJpc3MiOiJDaW5lIiwiYXVkIjoiQ2luZSJ9.MRjbxtj4SGMZ4ZXkWTAivrI2vXixrNLl6buZ75x18bY"
}
```

### Delete

#### Request

```json
{
  "email": "lmariar@gmail.com",
  "password": "123mn213"
}
```

#### Response

```json
{}
```

### GetAll

#### Request

```json
{}
```

#### Response

```json
{
  "partners": [
    {
      "address": "muylejos",
      "phoneNumber": "713-213-534",
      "points": 0,
      "password": "87654321",
      "id": "ff9ede3f-b34f-4cf9-b38d-2dda8cfb6656",
      "firstName": "caemllo",
      "lastName": "desierto",
      "email": "camello@gmail.com",
      "ci": "02101576123"
    },
    {
      "address": "Calle 1 #123",
      "phoneNumber": "787-123-1234",
      "points": 0,
      "password": "123mn213",
      "id": "1250bd0e-1256-4fb7-8729-4871c5066776",
      "firstName": "Laura Maria editada",
      "lastName": "Ramona",
      "email": "lmariar@gmail.com",
      "ci": "02101576475"
    }
  ]
}
```

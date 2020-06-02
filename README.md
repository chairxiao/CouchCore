### 安装
- CouchDB

### 新建数据库
- mydb
### 新建设计文档

- filter_person: 捕捉类型为person的变化
- getAll: 获取全部类型为person的文档

```
{
  "_id": "_design/person",
  "filters": {
    "filter_person": "function (doc,req) {\n  if(doc.$doctype !=\"person\")\n  {return false;}\n  return true;\n}"
  },
  "views": {
    "getAll": {
      "map": "function (doc) {\n  if(doc.$doctype && doc.$doctype == \"person\")\n  emit(doc._id, 1);\n}"
    }
  },
  "language": "javascript"
}
```


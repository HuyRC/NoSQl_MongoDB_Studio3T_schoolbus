using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

// ========== 1. SCHOOL ==========
public class School
{
    [BsonId]
    public ObjectId Id { get; set; }

    public string code { get; set; } = "";        // "GD", "LQD"
    public string name { get; set; } = "";        // Tên trường
    public string address { get; set; } = "";     // Địa chỉ
    public bool active { get; set; } = true;      // Còn hoạt động
}

// ========== 2. STUDENT ==========
public class Student
{
    [BsonId]
    public ObjectId Id { get; set; }

    public string mahs { get; set; } = "";        // Mã HS: "GD0001"
    public string hoten { get; set; } = "";
    public string lop { get; set; } = "";
    public DateTime ngaysinh { get; set; }        // ISODate trong Mongo
    public string phai { get; set; } = "";
    public string diachi { get; set; } = "";

    public string schoolCode { get; set; } = "";  // Mã trường logic ("GD")
    public ObjectId schoolId { get; set; }        // Tham chiếu vật lý
    public bool active { get; set; } = true;
}

// ========== 3. STOP (Điểm đón/trả) ==========
public class GeoPoint
{
    public string type { get; set; } = "Point";
    public double[] coordinates { get; set; } = new double[2]; // [long, lat]
}

public class Stop
{
    [BsonId]
    public ObjectId Id { get; set; }

    public string code { get; set; } = "";        // STOP_BT01
    public string name { get; set; } = "";
    public GeoPoint location { get; set; } = new(); // { type: "Point", coordinates: [...] }
    public string? note { get; set; }
    public string? schoolCode { get; set; }       // Liên kết vùng trường
    public bool active { get; set; } = true;
}

// ========== 4. ROUTE (Tuyến đường) ==========
public class RouteStop
{
    public int seq { get; set; }                  // Thứ tự chạm
    public string stopCode { get; set; } = "";
    public ObjectId stopId { get; set; }
    public string plannedTime { get; set; } = ""; // 06:25
}

public class Route
{
    [BsonId]
    public ObjectId Id { get; set; }

    public string code { get; set; } = "";        // R-GD-AM
    public string name { get; set; } = "";
    public string direction { get; set; } = "morning";
    public string schoolCode { get; set; } = "";
    public ObjectId schoolId { get; set; }
    public bool isActive { get; set; } = true;

    public List<RouteStop> stopOrder { get; set; } = new();
}

// ========== 5. DRIVER (Tài xế) ==========
public class Driver
{
    [BsonId]
    public ObjectId Id { get; set; }

    public string code { get; set; } = "";        // DRV001
    public string fullName { get; set; } = "";
    public string phone { get; set; } = "";
    public string? licenseNo { get; set; }
    public bool active { get; set; } = true;
}

// ========== 6. BUS (Xe) ==========
public class Bus
{
    [BsonId]
    public ObjectId Id { get; set; }

    public string code { get; set; } = "";        // BUS001
    public string plate { get; set; } = "";       // 51B-123.45
    public int capacity { get; set; }
    public string? brand { get; set; }
    public int? year { get; set; }
    public bool active { get; set; } = true;
}

// ========== 7. TRIP (Chuyến xe) ==========
public class Trip
{
    [BsonId]
    public ObjectId Id { get; set; }

    public string tripCode { get; set; } = "";    // TRIP-GD-AM-20251024
    public string routeCode { get; set; } = "";
    public ObjectId routeId { get; set; }
    public DateTime date { get; set; }            // new Date("2025-10-24")

    public string busCode { get; set; } = "";
    public ObjectId busId { get; set; }

    public string driverCode { get; set; } = "";
    public ObjectId driverId { get; set; }

    public string status { get; set; } = "planned"; // planned | started | finished
}

// ========== 8. ASSIGNMENT (Phân công HS) ==========
public class Assignment
{
    [BsonId]
    public ObjectId Id { get; set; }

    public string studentCode { get; set; } = "";
    public ObjectId studentId { get; set; }

    public string routeCode { get; set; } = "";
    public ObjectId routeId { get; set; }

    public string pickStopCode { get; set; } = "";
    public ObjectId pickStopId { get; set; }

    public string dropStopCode { get; set; } = "";
    public ObjectId dropStopId { get; set; }

    public List<string> days { get; set; } = new(); // ["Mon",...]
    public bool active { get; set; } = true;
}

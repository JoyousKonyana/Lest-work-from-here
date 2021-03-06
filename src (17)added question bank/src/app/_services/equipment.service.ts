import { CheckOut } from './../_models/checkoutModel';
import { ReportsModel } from './../_models/reportModel';
import { EquipmentQuery } from './../_models/equipmentquery';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Equipment, AssignEquipment, Equipment_Brand, Equipment_Type, Equipment_Query} from '../_models';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api/Equipment';  
   url2 ='https://localhost:44319/api/EquipmentBrand';
   url3 ='https://localhost:44319/api/EquipmentType';
   //  userId: any = localStorage.getItem('user');
  
   userId;
  constructor(private http: HttpClient) {
    
    var movies = localStorage.getItem("user");
    movies     = JSON.parse(movies);
    if(movies){
      this.userId = movies['id'];
      console.log(movies['id']);
    }
  }  

  getAllEquipment(): Observable<any[]> {  
    return this.http.get<any[]>(`${this.url}/GetAllEquipment`);  
  }
  
  getAllEquipment_Brand(): Observable<Equipment_Brand[]> {  
    return this.http.get<Equipment_Brand[]>(`${this.url2}/GetAllEquipmentBrands`);  
  } 

  getAllEquipment_Type(): Observable<Equipment_Type[]> {  
    return this.http.get<Equipment_Type[]>(`${this.url3}/GetAllEquipmentTypes`);  
  } 

  getEquipmentById(id: string): Observable<Equipment> {  
      return this.http.get<Equipment>(`${this.url + '/GetEquipmentById/' + id}`);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url}/DeleteEquipment/`+ id + '/' + this.userId);
  }

  update(id:number, equipment:Equipment) {
    return this.http.put(`${this.url}/UpdateEquipment/`+ id + '/' + this.userId, equipment);
  }

  create(equipment: Equipment) {
    return this.http.post(`${this.url}/RegisterEquipment/` + this.userId, equipment);
  }

  AssignEquipment(assignedEquipment:AssignEquipment){
    return this.http.post(`${this.url}/AssignedEquipment/`+ this.userId,assignedEquipment);
  }
  //used by onboarder
  GetAssignedEquipment(id: number){
    return this.http.get(`${this.url}/GetAssignedEquipment/`+ id);
  }
  
  ReportEquipmentQuery(equipmentQuery:Equipment_Query){
    return this.http.post(`${this.url}/ReportEquipmentQuery/` + this.userId, equipmentQuery);
  }

  generateEquipmentReport(reportdata: ReportsModel){
    return this.http.post(`${this.url}/GenerateEquipmentReport`,reportdata);
  }
  
  generateTradeInReport(reportdata: ReportsModel){
    return this.http.post(`${this.url}/GenerateTradeInReport`,reportdata);
  }

  checkoutEquipment(equipcheckout:CheckOut){
    return this.http.put(`${this.url}/EquipmentDueForTradeIn`,equipcheckout);
  }


  //Equipment Type
  deleteType(id: number) {
    return this.http.delete(`${this.url3}/DeleteEquipmentType/` + id + '/' + this.userId);
  }
  updateType(id: number, equipment_type: Equipment_Type) {
    return this.http.put(`${this.url3}/UpdateEquipmentType/` + id + '/' + this.userId, equipment_type);
  }
  createType(equipment_type: Equipment_Type) {
    return this.http.post(`${this.url3}/CreateEquipmentType/` + this.userId, equipment_type);
  }

  //Equipment Brand
  deleteBrand(id: number) {
    return this.http.delete(`${this.url2}/DeleteEquipmentBrand/` + id + '/' + this.userId);
  }
  updateBrand(id: number, equipment_type: Equipment_Brand) {
    return this.http.put(`${this.url2}/UpdateEquipmentBrand/` + id + '/' + this.userId, equipment_type);
  }
  createBrand(equipment_type: Equipment_Brand) {
    return this.http.post(`${this.url2}/CreateEquipmentBrand/` + this.userId, equipment_type);
  }

} 
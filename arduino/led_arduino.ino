int bir=1;
int iki=2;
int uc=3;
int dort=4;
int bes=5;
int alti=6;
int yedi=7;
int sekiz=8;
int dokuz =9;

void setup() {
  pinMode (bir,OUTPUT);
  pinMode (iki,OUTPUT);
  pinMode (uc,OUTPUT);
  pinMode (dort,OUTPUT);
  pinMode (bes,OUTPUT);
  pinMode (alti,OUTPUT);
  pinMode (yedi,OUTPUT);
  pinMode (sekiz,OUTPUT);
  pinMode (dokuz,OUTPUT);
  Serial.begin(9600);
  
}

void loop() {
int bolge=Serial.read();
if (bolge=='1'){
  digitalWrite(bir,HIGH);
  
  }  
else {
  digitalWrite(bir,LOW);
  }
  if (bolge=='2'){
  digitalWrite(iki,HIGH);
  
  }  
else {
  digitalWrite(iki,LOW);
  }
  if (bolge=='3'){
  digitalWrite(uc,HIGH);
  
  }  
else {
  digitalWrite(uc,LOW);
  }
  if (bolge=='4'){
  digitalWrite(dort,HIGH);
  
  }  
else {
  digitalWrite(dort,LOW);
  }
  if (bolge=='5'){
  digitalWrite(bes,HIGH);
  
  }  
else {
  digitalWrite(bes,LOW);
  }
  if (bolge=='6'){
  digitalWrite(alti,HIGH);
  
  }  
else {
  digitalWrite(alti,LOW);
  }
  if (bolge=='7'){
  digitalWrite(yedi,HIGH);
  
  }  
else {
  digitalWrite(yedi,LOW);
  }
  if (bolge=='8'){
  digitalWrite(sekiz,HIGH);
  
  }  
else {
  digitalWrite(sekiz,LOW);
  }
  if (bolge=='9'){
  digitalWrite(dokuz,HIGH);
  
  }  
else {
  digitalWrite(dokuz,LOW);
  }
}

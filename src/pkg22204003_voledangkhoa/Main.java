/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package pkg22204003_voledangkhoa;

import java.util.Arrays;
import java.util.Scanner;

/**
 *
 * @author SINHVIEN
 */
public class Main {
    public static void  bai10(){
        Scanner sc = new Scanner(System.in);
        System.err.println("Nhap vao thu: ");
        int n = sc.nextInt();
        switch(n){
            case 1:
                System.err.println("Chu nhat");
                break;
            case 2:
                System.err.println("Thu 2");
                break;
            case 3:
                System.err.println("Thu 3");
                break;
            case 4:
                System.err.println("Thu 4");
                break;
            case 5:
                System.err.println("Thu 5");
                break;
            case 6:
                System.err.println("Thu 6");
                break;
            case 7:
                System.err.println("Thu 7");
                break;
            default:
                System.err.println("Ban sai, chi duoc nhap so nguyen tu 1 den 7");
        }
    }
    public static void bangCuuChuong(){
        Scanner sc = new Scanner(System.in);
        System.err.println("Nhap so nguyen n:");
        int n = sc.nextInt();
        int tich = 1;
        for(int i = 1 ; i < 10 ; i ++){
            tich = i*n;
            System.err.println(n+"*"+i+"= "+tich);
        }
    }
    public static void sapXepMang(){
        Scanner sc = new Scanner(System.in);
        int n;
        System.err.println("Nhap so nguyen n:");
        n = sc.nextInt();
        int[] arr = new int[n];
        for(int i = 0 ; i < n ; i++)
        {
            System.err.println("Nhap "+i+": ");
            arr[i] = sc.nextInt();
        }
        System.err.println("Mang vua nhap");
        System.err.println( Arrays.toString(arr));

        for(int i = 0 ; i < n-1 ; i++){
            for(int j = 1; j < n ; j++){
                 if(arr[i]>arr[j]){
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }    
        }
        System.err.println("Mang vua sap xep:");
        System.err.println( Arrays.toString(arr));      
    }
    public static void chuoiSo(){
        Scanner sc = new Scanner(System.in);
        System.err.println("Nhap chuoi so: ");
        String chs = sc.nextLine();
        String[] m  = chs.split("\\s+");
        int[] songuyen = new int[m.length];
        for(int i = 0 ;  i < m.length ; i++){
            songuyen[i] = Integer.parseInt(m[i]);
        }
        System.err.println("Chuoi vua nhap co "+songuyen.length+" so nguyen");
        for(int i = 0 ; i<m.length; i++){
            if(ktraSNT((int)i))
                System.err.println( "So nguyen to la: "+m[i]); 
        }
    }
    public static void bai20(){
        for(int i = 100000 ; i<1000000 ; i++){
            if(checkTN(i))
                System.err.println(i);
        }
    }
    public static void main(String[] args) {
        //bai10();
        // bangCuuChuong();
        //sapXepMang();
        //chuoiSo();
        int i = 100000;
           for( i= 10000 ; i<1000000 ; i++){
            if(checkTN(i))
                System.err.println(i);
            }
    }
    
    public static boolean ktraSNT(int n){
        if(n<2){
            return false;
        }
        for(int i =2 ; i < n /2 ; i++){
            if(n%2==0){
                return false;
            }
        }
        return true;
    }
    
    public static boolean checkTN(int n){
        int a[] = new int[20];
        int dem = 0;
        while(n > 0){
            a[dem++] = n%10;
            n/=10;
        }
        for(int i = 0 ; i<a.length;i++){
            if(a[i]!=a[dem-i-1]){
                return false;
            }
        }return true;
    }
}

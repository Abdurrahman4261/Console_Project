
using System.Net.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class yonet : MonoBehaviourPunCallbacks
{
    public TMP_Text severbilgi; private Vector3Int posit;
    public TMP_InputField kulad,odaadi;
    string kulla_Adi;
    string oda_Adi;
    private Vector3 pos1,pos2, pos3,pos4,pos_grid,pos5,posses;
    
    private int sayac=0;
    private int[] lastNumber = new int [80];
    private int[] lastNumber2 = new int [80];
    public static GameObject grid , p1,p2;
    public static int yikilan_length;
    public static List<GameObject> yikilanlar = new List<GameObject>();
    public AudioSource kareses;
    
    void Start()
    {
        pos1 = new Vector3 (-15,8,0);
        pos2 = new Vector3 (11,8,0);
        pos3 = new Vector3 (-15,5,0);
        pos4 = new Vector3 (-11,8,0);
        pos5 = new Vector3 (-16,9,0);
        posses = new Vector3 (-50,9,0);
        
        // pos_grid = new Vector3 (-0.5f,0.5f,0);
        // sunucu lobi oda bağlanma sırası
        PhotonNetwork.ConnectUsingSettings(); // server bağlanma isteği
        DontDestroyOnLoad(gameObject); // sahne değişsede bu ogjeyi kaybetme demektir
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [PunRPC]
    public void yikilacakobje(){
        Debug.Log("yonet:"+yikilanlar.Count);
        for (int i = 0; i < yikilanlar.Count; i++)
        {
            Bomb_Player2.yikilanlar_yedek.Add( yikilanlar[i]);
        }
    }
    public void odakur(){
        SceneManager.LoadScene("Online_photon");
        kulla_Adi=kulad.text;
        oda_Adi=odaadi.text;
        PhotonNetwork.JoinLobby();
    }
    public void giris_Yap(){
        SceneManager.LoadScene("Online_photon");
        kulla_Adi=kulad.text;
        oda_Adi=odaadi.text;
        PhotonNetwork.JoinLobby();
    }
    public override void OnConnectedToMaster()
    {
        severbilgi.text= "Servera Bağlandı";
    }
    public void Duvar_Olusum(){
        for (var i = 0; i < 32; i++)
        {  
            if(i<4){
                GameObject nesne4 = PhotonNetwork.Instantiate("yikilan_online",pos4,Quaternion.identity,0,null);
                pos4 = new Vector2(pos4.x,pos4.y-1);
                yikilanlar.Add(nesne4);
                
            }
            else if(i<8){
                if(i==4){
                    pos4 = new Vector2(pos4.x,pos4.y+1);
                }
                pos4 = new Vector2(pos4.x-1,pos4.y);
                GameObject nesne4 = PhotonNetwork.Instantiate("yikilan_online",pos4,Quaternion.identity,0,null);
                yikilanlar.Add(nesne4);
            }
            else if(i<12){
                if(i==8){
                    pos4 = new Vector2 (7,8);
                }
                GameObject nesne4 = PhotonNetwork.Instantiate("yikilan_online",pos4,Quaternion.identity,0,null);
                yikilanlar.Add(nesne4);
                pos4 = new Vector2(pos4.x,pos4.y-1);
            }
            else if(i<16){
                if(i==12){
                    pos4 = new Vector2(pos4.x+1,pos4.y);
                    pos4 = new Vector2(pos4.x,pos4.y+1);
                }
                GameObject nesne4 = PhotonNetwork.Instantiate("yikilan_online",pos4,Quaternion.identity,0,null);
                yikilanlar.Add(nesne4);
                pos4 = new Vector2(pos4.x+1,pos4.y);
            }
            else if(i<20){
                if(i==16){
                    pos4 = new Vector2 (-11,-5);
                }
                GameObject nesne4 = PhotonNetwork.Instantiate("yikilan_online",pos4,Quaternion.identity,0,null);
                yikilanlar.Add(nesne4);
                pos4 = new Vector2(pos4.x,pos4.y+1);
            }
            else if(i<24){
                if(i==20){
                    pos4 = new Vector2(pos4.x,pos4.y-1);
                    pos4 = new Vector2(pos4.x-1,pos4.y);
                }
                GameObject nesne4 = PhotonNetwork.Instantiate("yikilan_online",pos4,Quaternion.identity,0,null);
                yikilanlar.Add(nesne4);
                pos4 = new Vector2(pos4.x-1,pos4.y);
            }
            else if(i<28){
                if(i==24){
                    pos4 = new Vector2(7,-5);
                }
                GameObject nesne4 = PhotonNetwork.Instantiate("yikilan_online",pos4,Quaternion.identity,0,null);
                yikilanlar.Add(nesne4);
                pos4 = new Vector2(pos4.x,pos4.y+1);
            }
            else if(i<32){
                if(i==28){
                    pos4 = new Vector2(pos4.x,pos4.y-1);
                    pos4 = new Vector2(pos4.x+1,pos4.y);
                }
                GameObject nesne4 = PhotonNetwork.Instantiate("yikilan_online",pos4,Quaternion.identity,0,null);
                yikilanlar.Add(nesne4);
                pos4 = new Vector2(pos4.x+1,pos4.y);
            }
            
            if(!PhotonNetwork.IsMasterClient){ 
                yikilan_length++;
                continue;
            }
        }
        
        Debug.Log("1."+yikilanlar[1].transform.position);
    }
    public void Yikilmaz(){
        for (var i = 0; i < 86; i++)
        {
            if(i<28){ // pos5 (-16,9)
                pos5 = new Vector2(pos5.x+1,pos5.y);
                GameObject nesne5 = PhotonNetwork.Instantiate("yıkılmaz_online",pos5,Quaternion.identity,0,null);
            }
            else if(i<43){ // pos5 (12,9)
                pos5 = new Vector2(pos5.x,pos5.y-1);
                GameObject nesne5 = PhotonNetwork.Instantiate("yıkılmaz_online",pos5,Quaternion.identity,0,null);
            }
            else if(i<71){ // pos5 (12,9)
                pos5 = new Vector2(pos5.x-1,pos5.y);
                GameObject nesne5 = PhotonNetwork.Instantiate("yıkılmaz_online",pos5,Quaternion.identity,0,null);
            }
            else if(i<86){ // pos5 (12,9)
                pos5 = new Vector2(pos5.x,pos5.y+1);
                GameObject nesne5 = PhotonNetwork.Instantiate("yıkılmaz_online",pos5,Quaternion.identity,0,null);
            }
        }
    }
    // [PunRPC]
    // public void yedek(){
    //     if(PhotonNetwork.IsMasterClient) return;
    //     for (int i = 0; i < yikilanlar.Count; i++)
    //     {
    //         yikilanlar_yedek.Add(yikilanlar[i]);
    //         yikilanlar_yedek[i].SetActive(false);
    //     }
    //     yikilan_length=yikilanlar_yedek.Count;
    // }
    public override void OnJoinedLobby()
    {
        if(kulla_Adi!="" && oda_Adi != ""){
            PhotonNetwork.JoinOrCreateRoom (oda_Adi, new RoomOptions {MaxPlayers = 4 , IsOpen = true , IsVisible = true},TypedLobby.Default);
        }
        // else if(kulla_Adi!=""){
        
        //     PhotonNetwork.JoinRandomRoom();
        // }
        else{
            PhotonNetwork.JoinRandomRoom();
            //Debug.Log("en azında kullanıcı adını gir");
        }
    }
    public override void OnJoinedRoom()
    {
        // GameObject kare = PhotonNetwork.Instantiate("square",posses,Quaternion.identity,0,null);
        // kareses = kare.GetComponent<AudioSource>();
        // kareses.enabled= true;
        InvokeRepeating("isimbilgikontrol",0,1f);
        if(PhotonNetwork.IsMasterClient){
            Yikilmaz();
            Duvar_Olusum();
            //grid = PhotonNetwork.Instantiate("Bolum_online",pos_grid,Quaternion.identity);
            GameObject p1 = PhotonNetwork.Instantiate("multi_1",pos1,Quaternion.identity,0,null);
            p1.GetComponent<PhotonView>().Owner.NickName = kulla_Adi;
            for (int i=0;i<45;i++){
                sayac=0;
                posit.x = Random.Range(-6,3);
                posit.y = Random.Range(-1,4);
                
                for(int j=0;j<44;j++){
                
                    if(posit.x == lastNumber[j]  && posit.y == lastNumber2[j]){
                        sayac=lastNumber.Length; 
                        i--;
                        break;
                    }
                }
                if(sayac==lastNumber.Length){
                    continue;
                }
                lastNumber[i] = posit.x; 
                lastNumber2[i] = posit.y;
            
                int gift = Random.Range(0,6);
                if(gift == 0 ){
                    GameObject ates = PhotonNetwork.Instantiate("hediye_ates_online",posit,Quaternion.identity);
                }
                else if(gift == 1 ){
                    GameObject ates_az = PhotonNetwork.Instantiate("hediye_ates_az_online",posit,Quaternion.identity);
                }
                else if(gift == 2 ){
                    GameObject bilinmeyen = PhotonNetwork.Instantiate("hediye_bilinmeyen_online",posit,Quaternion.identity);
                }
                else if(gift == 3 ){
                    GameObject bomb = PhotonNetwork.Instantiate("hediye_bomb_online",posit,Quaternion.identity);
                }
                else if(gift == 4 ){
                    GameObject hiz = PhotonNetwork.Instantiate("hediye_hiz_online",posit,Quaternion.identity);
                }
                else if(gift == 5 ){
                    GameObject tekme = PhotonNetwork.Instantiate("hediye_tekme_online",posit,Quaternion.identity);
                }
            }
            GameObject.FindWithTag("PlayerOne"). GetComponent<PhotonView>().RPC("ilkboyut2",RpcTarget.All,null);
        }
        else{
            //GameObject.Find("yonet").GetComponent<PhotonView>().RPC("yedek",RpcTarget.All,null);
            Duvar_Olusum();
            p2 = PhotonNetwork.Instantiate("multi_2",pos2,Quaternion.identity,0,null);
            p2.GetComponent<PhotonView>().Owner.NickName = kulla_Adi;
            GameObject.FindWithTag("player2"). GetComponent<PhotonView>().RPC("ilkboyut2",RpcTarget.All);
            //Debug.Log("yikilan_length:"+yikilan_length);
        }
    }
    public override void OnPlayerLeftRoom(Player otherPlayer){
        InvokeRepeating("isimbilgikontrol",0,1f);
    }
    public override void OnPlayerEnteredRoom(Player otherPlayer){
        // herhangi bir oyuncu girdiğinde
    }
    void isimbilgikontrol(){
        
        if(PhotonNetwork.PlayerList.Length==2){
            GameObject.FindWithTag("bekleme").GetComponent<TextMeshProUGUI>().text = "";
            GameObject.FindWithTag("oyuncu1_name").GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[0].NickName;
            GameObject.FindWithTag("oyuncu2_name").GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[1].NickName;
            CancelInvoke("isimbilgikontrol");
        }
        else{;
            GameObject.FindWithTag("bekleme").GetComponent<TextMeshProUGUI>().text = "Oyuncu Bekleniyor";
            GameObject.FindWithTag("oyuncu1_name").GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[0].NickName;
            GameObject.FindWithTag("oyuncu2_name").GetComponent<TextMeshProUGUI>().text = "...";
        }
    }
    public override void OnLeftLobby()
    {
        Debug.Log("lobiden cikildi");
    }
    public override void OnLeftRoom()
    {
        Debug.Log("odadan cikildi");
    }
    public override void OnJoinRoomFailed(short returnCode , string message)
    {
        Debug.Log("Hata : Odaya girilemedi");
    }
    public override void OnJoinRandomFailed(short returnCode , string message)
    {
        Debug.Log("Hata : Herhangi bir odaya girilemedi");
    }
    public override void OnCreateRoomFailed(short returnCode , string message)
    {
        Debug.Log("Hata : Oda kurulamadi");
    }
}

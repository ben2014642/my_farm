<?php
if(isset($_GET['xem'])) {
echo'<div class="main-xmenu">';
echo'<div class="phdr"><center>Nông Trại</center></div>';
if (!$user_id){
echo'<div class="menu">Bạn phải đăng nhập để chơi game này nhé !</div>';
echo'</div>';
require('../incfiles/end.php');
exit;
}
echo'<style>body{min-width: 500px}</style>';
date_default_timezone_set('Asia/Ho_Chi_Minh');
$kiemtra = date("H");
echo'<div class="cola" style="padding: 0;margin-bottom: 2px;margin-top: 3px;">'.($kiemtra >= 6 && $kiemtra <= 18? '<div class="nennongtrai"><marquee behavior="scroll" direction="left" scrollamount="1" style="margin-top: 5px"><img src="/icon/iconxoan/dammaynho.png"></marquee><marquee behavior="scroll" direction="left" scrollamount="2" style="margin-top: 10px"><img src="/icon/iconxoan/dammaylon.png"></marquee>' :'<div class="nennongtrai_toi">').'</div>';
echo'<div style="margin-top: -70px;text-align: center;">';
echo'<a href="/farm/"><img src="/icon/farm.png"></a><a href="/atm/"><img src="/icon/atm.png"></a>';
echo'<a href="/farm/shop.php"><img src="../icon/cuahangfarm.png"></a></div>';
echo'<div class="dat">';
echo'<a href="laibuon.php"><img src="/icon/laibuon.gif" style="position:absolute;vertical-align: 0px;margin:-40px 0 0 60px;"></a>';
//--code này copy để hiện avatar by cRoSsOver--//
//update nơi đang online và tọa độ
mysql_query("UPDATE `vitri` SET `time`='".time()."',`online`='".$textl."',`toado`='".$toado."' WHERE `user_id`='".$user_id."'");
$time=time()-300;
//bắt đầu cho hiện avatar
$req=mysql_query("SELECT * FROM `vitri` WHERE `online`='".$textl."' AND `time`>'".$time."'");
while($pr = mysql_fetch_array($req))
    {
$name=mysql_fetch_array(mysql_query("SELECT * FROM `users` WHERE `id`='".$pr[user_id]."'"));
$flip=rand(1,2);
if($flip==1) {$flip=' class="flip"';}
else {$flip='';}
        echo '<center><a href="/member/'.$pr['user_id'].'.html"><label style="display: inline-block;text-align: center;"><b style="font-size: 9px;color:red;font-weight:bold;text-align: center;">'.$name[name].'</b><br><img src="/avatar/'.$pr[user_id].'.png"></label></a></center>';
}
echo'</div>';
echo'</div>';
echo'</div>';
require('../incfiles/end.php');
exit;
}
?>
                            
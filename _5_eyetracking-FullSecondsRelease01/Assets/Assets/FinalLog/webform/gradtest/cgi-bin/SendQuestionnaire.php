<?php

/**
 * Konfiguration 
 *
 * Bitte passen Sie die folgenden Werte an, bevor Sie das Script benutzen!
 * 
 * Das Skript bitte in UTF-8 abspeichern (ohne BOM).
 */
 
// An welche Adresse sollen die Mails gesendet werden?
$zieladresse = 'test-in@given-communication.de';
// Welche Adresse soll als Absender angegeben werden?
// (Manche Hoster lassen diese Angabe vor dem Versenden der Mail ueberschreiben)
$absenderadresse = 'test-send@given-communication.de';

// Welcher Absendername soll verwendet werden?
$absendername = 'test-send';

// Welchen Betreff sollen die Mails erhalten?
$betreff = 'SpiderExperiment';

// Zu welcher Seite soll als "Danke-Seite" weitergeleitet werden?
// Wichtig: Sie muessen hier eine gueltige HTTP-Adresse angeben!
$urlDankeSeite = 'http://www.given-communication.de/gesendet.htm';

// Welche(s) Zeichen soll(en) zwischen dem Feldnamen und dem angegebenen Wert stehen?
$trenner = "#"; // Doppelpunkt + Tabulator

/**
 * Ende Konfiguration
 */

if ($_SERVER['REQUEST_METHOD'] === "POST") {

	$header = array();
	$header[] = "From: ".mb_encode_mimeheader($absendername, "utf-8", "Q")." <".$absenderadresse.">";
	$header[] = "MIME-Version: 1.0";
	$header[] = "Content-type: text/plain; charset=utf-8";
	$header[] = "Content-transfer-encoding: 8bit";
	
    $mailtext = "We will be in touch with you shortly with your code.";

    foreach ($_POST as $name => $wert) {
        if (is_array($wert)) {
		    foreach ($wert as $einzelwert) {
			    $mailtext .= $name.$trenner.$einzelwert."\n";
            }
        } else {
            $mailtext .= $name.$trenner.$wert."\n";
        }
    }

    mail(
    	$zieladresse, 
    	mb_encode_mimeheader($betreff, "utf-8", "Q"), 
    	$mailtext,
    	implode("\n", $header)
    ) or die("Your mail was not sent. Please use the back button in your browser to return to the form and send it again. In most browser it will still be filled out.");
	{
echo "<p><span class='colorTextBlue'>E-mail sent successfully</span></p>";
echo "<p>Thank you for your interest and assistance in this experiment. The student researcher will send you a code as soon as possible.";
echo "<p>If you want to get in contact before send an email to: ";
echo '<a href="mailto:jogi1800@student.miun.se?subject=Data%20for%20Spider%20Experiment&amp;body=Dear%20Researcher,">jogi1800@student.miun.se</a>';

}
    exit;

}


header("Content-type: text/html; charset=utf-8");

?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="de">
    <head>
        <title>Einfacher PHP-Formmailer</title>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    </head>
    <body>
        <h1>Beispielformular</h1>
        <form action="" method="post">
            <!-- Hier die eigentlichen Formularfelder eintragen. Die folgenden sind Beispielangaben. -->
            <dl>
              <dt>fname:</dt>
                <dd><input type=text name="fname"/></dd>

<dt>lname:</dt>
                <dd><input type=text name="lname"/></dd>

<dt>company:</dt>
                <dd><input type=text name="company"/></dd>

<dt>email:</dt>
                <dd><input type=text name="email"/></dd>

<dt>q1a:</dt>
                <dd><input type=text name="q1a"/></dd>

<dt>q2a:</dt>
                <dd><input type=text name="q2a"/></dd>

<dt>q3a:</dt>
                <dd><input type=text name="q3a"/></dd>

<dt>q4a:</dt>
                <dd><input type=text name="q4a"/></dd>

<dt>q5a:</dt>
                <dd><input type=text name="q5a"/></dd>

<dt>q6a:</dt>
                <dd><input type=text name="q6a"/></dd>

<dt>q7a:</dt>
                <dd><input type=text name="q7a"/></dd>

<dt>q8a:</dt>
                <dd><input type=text name="q8a"/></dd>

<dt>q9a:</dt>
                <dd><input type=text name="q9a"/></dd>

<dt>q10a:</dt>
                <dd><input type=text name="q10a"/></dd>

<dt>q11a:</dt>
                <dd><input type=text name="q11a"/></dd>

<dt>q12a:</dt>
                <dd><input type=text name="q12a"/></dd>

<dt>q13a:</dt>
                <dd><input type=text name="q13a"/></dd>

<dt>q14a:</dt>
                <dd><input type=text name="q14a"/></dd>

<dt>q15a:</dt>
                <dd><input type=text name="q15a"/></dd>

<dt>q16a:</dt>
                <dd><input type=text name="q16a"/></dd>

<dt>q17a:</dt>
                <dd><input type=text name="q17a"/></dd>

<dt>q18a:</dt>
                <dd><input type=text name="q18a"/></dd>

<dt>q19a:</dt>
                <dd><input type=text name="q19a"/></dd>

<dt>q20a:</dt>
                <dd><input type=text name="q20a"/></dd>

<dt>q21a:</dt>
                <dd><input type=text name="q21a"/></dd>

<dt>q22a:</dt>
                <dd><input type=text name="q22a"/></dd>

<dt>q23a:</dt>
                <dd><input type=text name="q23a"/></dd>

<dt>q24a:</dt>
                <dd><input type=text name="q24a"/></dd>

<dt>q25a:</dt>
                <dd><input type=text name="q25a"/></dd>

<dt>q26a:</dt>
                <dd><input type=text name="q26a"/></dd>

<dt>q27a:</dt>
                <dd><input type=text name="q27a"/></dd>
<dt>§q27b:</dt>
                <dd><input type=text name="q27b"/></dd>

<dt>q28a:</dt>
                <dd><input type=text name="q28a"/></dd>
<dt>§q28b:</dt>
                <dd><input type=text name="q28b"/></dd>

<dt>q29a:</dt>
                <dd><input type=text name="q29a"/></dd>

<dt>q30a:</dt>
                <dd><input type=text name="q30a"/></dd>

<dt>q31a:</dt>
                <dd><input type=text name="q31a"/></dd>

<dt>q32a:</dt>
                <dd><input type=text name="q32a"/></dd>

<dt>q33a:</dt>
                <dd><input type=text name="q33a"/></dd>

<dt>q34a:</dt>
                <dd><input type=text name="q34a"/></dd>

<dt>q35a:</dt>
                <dd><input type=text name="q35a"/></dd>

<dt>q36a:</dt>
                <dd><input type=text name="q36a"/></dd>

<dt>q37a:</dt>
                <dd><input type=text name="q37a"/></dd>

<dt>q38a:</dt>
                <dd><input type=text name="q38a"/></dd>

<dt>q39a:</dt>
                <dd><input type=text name="q39a"/></dd>
<dt>§q39b:</dt>
                <dd><input type=text name="q39b"/></dd>

<dt>q40a:</dt>
                <dd><input type=text name="q40a"/></dd>

<dt>q41a:</dt>
                <dd><input type=text name="q41a"/></dd>

<dt>q42a:</dt>
                <dd><input type=text name="q42a"/></dd>

<dt>q43a:</dt>
                <dd><input type=text name="q43a"/></dd>

<dt>q44a:</dt>
                <dd><input type=text name="q44a"/></dd>

<dt>q45a:</dt>
                <dd><input type=text name="q45a"/></dd>

<dt>q46a:</dt>
                <dd><input type=text name="q46a"/></dd>

<dt>q47a:</dt>
                <dd><input type=text name="q47a"/></dd>

<dt>q48a:</dt>
                <dd><input type=text name="q48a"/></dd>

<dt>q49a:</dt>
                <dd><input type=text name="q49a"/></dd>

<dt>q50a:</dt>
                <dd><input type=text name="q50a"/></dd>

<dt>q51a:</dt>
                <dd><input type=text name="q51a"/></dd>

<dt>q52a:</dt>
                <dd><input type=text name="q52a"/></dd>

<dt>q53a:</dt>
                <dd><input type=text name="q53a"/></dd>

<dt>q54a:</dt>
                <dd><input type=text name="q54a"/></dd>

<dt>q55a:</dt>
                <dd><input type=text name="q55a"/></dd>
<dt>§q55b:</dt>
                <dd><input type=text name="q55b"/></dd>

<dt>q56a:</dt>
                <dd><input type=text name="q56a"/></dd>
<dt>§q56b:</dt>
                <dd><input type=text name="q56b"/></dd>

<dt>q57a:</dt>
                <dd><input type=text name="q57a"/></dd>
<dt>§q57b:</dt>
                <dd><input type=text name="q57b"/></dd>

<dt>q58a:</dt>
                <dd><input type=text name="q58a"/></dd>
<dt>§q58b:</dt>
                <dd><input type=text name="q58b"/></dd>

<dt>q59a:</dt>
                <dd><input type=text name="q59a"/></dd>

<dt>q60a:</dt>
                <dd><input type=text name="q60a"/></dd>

<dt>q61a:</dt>
                <dd><input type=text name="q61a"/></dd>

<dt>q62a:</dt>
                <dd><input type=text name="q62a"/></dd>

<dt>q63a:</dt>
                <dd><input type=text name="q63a"/></dd>

<dt>q64a:</dt>
                <dd><input type=text name="q64a"/></dd>

<dt>q65a:</dt>
                <dd><input type=text name="q65a"/></dd>

<dt>q66a:</dt>
                <dd><input type=text name="q66a"/></dd>

<dt>q67a:</dt>
                <dd><input type=text name="q67a"/></dd>

<dt>q68a:</dt>
                <dd><input type=text name="q68a"/></dd>

<dt>q69a:</dt>
                <dd><input type=text name="q69a"/></dd>

<dt>q70a:</dt>
                <dd><input type=text name="q70a"/></dd>

<dt>q71a:</dt>
                <dd><input type=text name="q71a"/></dd>

<dt>q72a:</dt>
                <dd><input type=text name="q72a"/></dd>

<dt>q73a:</dt>
                <dd><input type=text name="q73a"/></dd>

<dt>q74a:</dt>
                <dd><input type=text name="q74a"/></dd>

<dt>q75a:</dt>
                <dd><input type=text name="q75a"/></dd>

<dt>q76a:</dt>
                <dd><input type=text name="q76a"/></dd>
<dt>§q76b:</dt>
                <dd><input type=text name="q76b"/></dd>

<dt>q77a:</dt>
                <dd><input type=text name="q77a"/></dd>
<dt>§q77b:</dt>
                <dd><input type=text name="q77b"/></dd>

<dt>q78a:</dt>
                <dd><input type=text name="q78a"/></dd>
<dt>§q78b:</dt>
                <dd><input type=text name="q78b"/></dd>

<dt>q79a:</dt>
                <dd><input type=text name="q79a"/></dd>
<dt>§q79b:</dt>
                <dd><input type=text name="q79b"/></dd>

<dt>q80a:</dt>
                <dd><input type=text name="q80a"/></dd>

<dt>q81a:</dt>
                <dd><input type=text name="q81a"/></dd>

<dt>q82a:</dt>
                <dd><input type=text name="q82a"/></dd>

<dt>q83a:</dt>
                <dd><input type=text name="q83a"/></dd>

<dt>q84a:</dt>
                <dd><input type=text name="q84a"/></dd>

<dt>q85a:</dt>
                <dd><input type=text name="q85a"/></dd>

<dt>q86a:</dt>
                <dd><input type=text name="q86a"/></dd>

<dt>q87a:</dt>
                <dd><input type=text name="q87a"/></dd>

<dt>q88a:</dt>
                <dd><input type=text name="q88a"/></dd>

<dt>q89a:</dt>
                <dd><input type=text name="q89a"/></dd>

<dt>q90a:</dt>
                <dd><input type=text name="q90a"/></dd>
<dt>§q90b:</dt>
                <dd><input type=text name="q90b"/></dd>

<dt>q91a:</dt>
                <dd><input type=text name="q91a"/></dd>
<dt>§q91b:</dt>
                <dd><input type=text name="q91b"/></dd>

<dt>q92a:</dt>
                <dd><input type=text name="q92a"/></dd>
<dt>§q92b:</dt>
                <dd><input type=text name="q92b"/></dd>

<dt>q93a:</dt>
                <dd><input type=text name="q93a"/></dd>
<dt>§q93b:</dt>
                <dd><input type=text name="q93b"/></dd>

<dt>q94a:</dt>
                <dd><input type=text name="q94a"/></dd>
<dt>§q94b:</dt>
                <dd><input type=text name="q94b"/></dd>

<dt>q95a:</dt>
                <dd><input type=text name="q95a"/></dd>
<dt>§q95b:</dt>
                <dd><input type=text name="q95b"/></dd>

<dt>q96a:</dt>
                <dd><input type=text name="q96a"/></dd>
<dt>§q96b:</dt>
                <dd><input type=text name="q96b"/></dd>

<dt>q97a:</dt>
                <dd><input type=text name="q97a"/></dd>
<dt>§q97b:</dt>
                <dd><input type=text name="q97b"/></dd>

<dt>q98a:</dt>
                <dd><input type=text name="q98a"/></dd>

<dt>q99a:</dt>
                <dd><input type=text name="q99a"/></dd>

<dt>q100a:</dt>
                <dd><input type=text name="q100a"/></dd>

<dt>q101a:</dt>
                <dd><input type=text name="q101a"/></dd>

<dt>q102a:</dt>
                <dd><input type=text name="q102a"/></dd>

<dt>q103a:</dt>
                <dd><input type=text name="q103a"/></dd>

<dt>q104a:</dt>
                <dd><input type=text name="q104a"/></dd>
            </dl>
            <!-- Ende der Beispielangaben -->
            <p>
            <input type="submit" value="Senden" />
            <input type="reset" value="Zurücksetzen" />
			<INPUT TYPE="hidden" NAME="success" VALUE="http://www.given-communication.de/gesendet.htm"/>
            </p>
        </form>
    </body>
</html>
<html>
    <body>
		<form>
		</span></span><span
 style="font-family: Century Gothic; color: rgb(51, 51, 51);"><a
 style="color: rgb(51, 51, 51);" href="Coaching.htm">Thank you for taking part in our online test. Please check your inbox. You should have recieved an email from us. if this is not the case, please contact us.</a></span></a><br>
		
		</form>
		</body>
</html>

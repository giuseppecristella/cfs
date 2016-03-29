<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Shop.Master" AutoEventWireup="true" CodeBehind="Spedizioni.aspx.cs" Inherits="Shop.Web.Mvp.Catalog.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <section class="page-contact text-center page-header">
        <header class="page-title">
            <h1>Spedizioni</h1>
        </header>
    </section>
    <section class="contact-form container ">
        <div class="row">
            <div class="col-md-10 center-block">
                <h3 class="form-title">1 Modalità di spedizione</h3>
                <p>
                    I tempi di consegna sono espressi in giorni lavorativi e partono dalla data dell’ordine (sabato, domenica e festivi esclusi). Per problemi dettati da cause di forza maggiore, Calzafacile.it non potrà essere considerata responsabile del ritardo nelle consegne.
                </p>
                <h3 class="form-title">2 Soddisfatti o rimborsati</h3>
                <p>
                    Tutti gli articoli acquistati sul sito Calzafacile.it possono essere oggetto di un cambio o di un rimborso. Per essere accettati, i resi devono rispettare le seguenti condizioni:
                    - Il prodotto non deve essere stato indossato in esterno. Il prodotto deve essere nuovo.
                    - Il prodotto deve essere reso nella confezione originale che a sua volta deve essere nuova.
                    - Il prodotto deve essere reso nei 7 giorni che seguono il ricevimento dell’ordine.
                </p>
                <h4 class="form-title">2.2 : La procedura di reso è la seguente:</h4>
                <p>
                    Tutti gli articoli acquistati sul sito Calzafacile.it possono essere oggetto di un cambio o di un rimborso.
                    Il reso per la Svizzera è a carico del cliente.
                    Il cliente può chiedere il cambio o il reso nei 7 giorni a partire dalla data di ricevimento degli articoli.
                    Il reso del o degli articoli deve imperativamente seguire la procedura qui sotto indicata:
                </p>
                <h3 class="form-title">Fase 1: Scheda cliente</h3>
                <p>
                    Collegarsi alla propria Scheda cliente nel sito Calzafacile.it con il proprio indirizzo email e password ed accedere inoltrando una mail ad info@Calzafacile.it 
                    mettendo come oggetto: «Restituzioni», «Effettua una richiesta di restituzioni» indicando tutti i dettagli tecnici del prodotto.
                </p>
                <h4 class="form-title">Fase 2: Stampare l’etichetta</h4>
                <p>
                    - Se il reso è offerto da Calzafacile.it: sarà inviata al cliente una e-mail con un link per stampare un'etichetta prepagata.
                    - Se il reso è a carico del cliente: sarà inviata una e-mail con l’indirizzo al quale dovrà essere rinviata la merce a carico del cliente.
                </p>
                <h4 class="form-title">Fase 3: Ritiro o invio del pacco</h4>
                <p>
                    Se il reso è offerto da Calzafacile.it: Il cliente dovrà contattare il corriere al numero indicato nella e-mail e mettersi d’accordo con loro per un appuntamento per il ritiro della merce a domicilio.
                    - Se il reso è a carico del cliente: Il cliente dovrà recarsi presso il trasportatore scelto ed inviare la merce all’indirizzo indicato.
                    Le spese di reso di un Prodotto Partner sono a carico del cliente. Al momento della restituzione il cliente deve effettuare in prima persona il pagamento delle spese di reso. Le spese di restituzione presso il venditore sono a carico dello stesso nel caso in cui il reso sia dovuto ad un errore del Venditore (articolo non conforme all’ordine del cliente, articolo non conforme alla scheda prodotto riportata sul sito, articolo danneggiato).
                    Il reso viene trattato in 7/10 giorni lavorativi.
                </p>
                <h3 class="form-title">3 Trattamento dei colli non consegnati dal nostro corriere</h3>
                <p>
                    Si tratta dei colli che non sono stati recapitati al destinatario finale per i motivi seguenti: destinatario sconosciuto, non reclamato, rifiutato, danneggiamento durante il trasporto, manomissione...
                </p>
                <h4 class="form-title">3.1 : Causa di restituzione del collo: destinatario sconosciuto o anomalia indirizzo</h4>
                <p>Si tratta dei colli rispediti al mittente dal corriere per la seguente ragione: Il destinatario non abita all'indirizzo indicato. In seguito alla ricezione e all'accettazione del collo da parte dei nostri servizi, Calzafacile.it contatterà il cliente per inviare nuovamente l'ordine se il prodotto è ancora disponibile oppure procedere al rimborso, in base alla scelta del cliente. Calzafacile.it si riserva il diritto di procedere al rimborso anziché ad un nuovo invio dell'ordine qualora vengano rilevati più invii rispediti al mittente con destinatario sconosciuto</p>

                <h3 class="form-title">3.2:  Causa di restituzione del collo: "ASSENTE / AVVISATO"</h3>
                <p>
                    Si tratta dei colli che non sono stati ritirati dal cliente presso la sede del corriere o presso il punto di consegna entro i termini previsti. In seguito alla ricezione e all'accettazione del collo da parte dei nostri servizi, Calzafacile.it contatterà il cliente per inviare nuovamente l'ordine se il prodotto è ancora disponibile oppure procedere al rimborso dell'ordine a seconda della scelta del cliente. Calzafacile.it si riserva il diritto di procedere al rimborso dell'ordine anziché al nuovo invio qualora in presenza di più invii non reclamati.
                </p>
                <h4 class="form-title">3.3:  Causa di restituzione del collo: "RIFIUTATO"</h4>
                <p>
                    Al momento della consegna, il cliente ha rifiutato il collo. In seguito alla ricezione e all'accettazione del collo da parte dei nostri servizi, vi verrà accreditato sul conto cliente un buono acquisto entro le 72 ore successive al ritorno del collo. È possibile richiedere l'annullamento del buono acquisto e il relativo rimborso nella sezione "SERVIZIO CLIENTI". In caso di restituzione di un collo dovuta alle cause "DESTINATARIO SCONOSCIUTO", "NON RECLAMATO", o "RIFIUTATO", Calzafacile.it non garantisce la prenotazione degli articoli ordinati e potrà essere obbligato a procedere al rimborso dell'ordine qualora il prodotti o i prodotti non siano disponibili.
                </p>
                <h3 class="form-title">4  Responsabilità</h3>
                <p>
                    Su tutte le fasi di accesso al sito, consultazione, compilazione dei moduli, esecuzione dell'ordine, consegna degli articoli o su qualsiasi altro servizio, la società Calzafacile.it si assume esclusivamente un obbligo di intermediazione. Pertanto, Calzafacile.it declina ogni responsabilità per gli inconvenienti o i danni derivati dall'utilizzo della rete Internet e totalmente estranei agli obblighi e alle precauzioni adottate da Calzafacile.it. In particolare, tutti gli imprevisti relativi alla fornitura del servizio, le intrusioni esterne o la presenza di virus informatici non saranno imputabili a Calzafacile.it. Analogamente, tutto ciò che risulti causa di forza maggiore ai sensi di quanto stabilito dalla Corte di Cassazione esonera totalmente Calzafacile.it da qualunque responsabilità. I clienti godono delle garanzie previste dalle marche presenti nel sito.
                </p>
                <h3 class="form-title">5  Proprietà intellettuale</h3>
                <p>
                    Tutti gli elementi del sito Calzafacile.it, visivi o sonori, compresa la tecnologia che li supporta, sono protetti da diritto d'autore, dei marchi o dei brevetti. Tali elementi sono di proprietà esclusiva di Calzafacile.it.
                    Tutti i collegamenti ipertestuali che rinviano al sito di Calzafacile.it e che utilizzano in particolare le tecniche del framing, deep-linking, in-line linking o tecniche di altro tipo di collegamento diretto sono tassativamente e formalmente vietati. Senza eccezioni, tutti i collegamenti, seppur tacitamente autorizzati, dovranno essere ritirati su richiesta di Calzafacile.it.
                </p>
                <h3 class="form-title">6 Dati nominativi</h3>
                <p>
                    Calzafacile.it, per esigenze di servizio, si riserva il diritto di raccogliere i dati nominativi relativi agli utenti del sito, in particolare attraverso il "cookie" descritto nell'articolo 8. In questo senso, il sito Calzafacile.it è registrato presso il CNIL con il numero : 1182432. Inoltre, Calzafacile.it si riserva il diritto di cessione, a fini commerciali, dei dati raccolti nel proprio sito.
                    In ogni caso, e in accordo a quanto stabilito dalla Legge N. 78-17 del 6 gennaio 1978, tutti gli utenti o i clienti del sito possono in qualsiasi momento opporsi all'utilizzo commerciale dei propri dati e avvalersi inoltre del diritto di accesso, rettifica ed eliminazione dei propri dati personali. Tutte le richieste relative al presente articolo dovranno essere inoltrate attraverso la sezione "Aiuto" della pagina iniziale del sito.
                    Potrai gestire i tuoi abbonamenti alla nostra Newletters, le nostre email ed i nostri SMS o anche chiedere la cancellazione dei tuoi dati tramite la rubrica dedicata ai tuoi abbonamenti
                </p>
            </div>
        </div>
    </section>
</asp:Content>

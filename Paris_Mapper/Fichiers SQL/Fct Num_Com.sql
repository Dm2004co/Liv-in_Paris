SELECt distinct ID_Commandes from Commande com 
WHERE ID_Client = @ID_Client
AND ID_Cuisto = @ID_Cuisto; 
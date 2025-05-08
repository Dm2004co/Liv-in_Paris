import networkx as nx
import matplotlib.pyplot as plt
import json

def create_graph_from_edge_list(edge_list_json, node_data_json):
    """
    Crée un graphe à partir d'une liste d'arêtes au format JSON et ajoute des nœuds
    avec les données fournies.

    Args:
        edge_list_json (str): Une chaîne contenant une liste JSON d'objets arêtes.
            Chaque objet arête doit contenir les champs nécessaires pour définir une arête.
            Dans ce cas, nous utiliserons 'ID_Client' et 'ID_Cuisto' pour définir les arêtes.
        node_data_json (str): Une chaîne contenant une liste JSON d'objets nœuds.
            Chaque objet nœud doit contenir les détails de la personne.
    Returns:
        networkx.Graph: Un graphe networkx.Graph.
    """
    try:
        # Charger la liste des arêtes à partir de la chaîne JSON
        edge_list = json.loads(edge_list_json)
        # Charger les données des nœuds à partir de la chaîne JSON
        node_data = json.loads(node_data_json)
    except json.JSONDecodeError as e:
        raise ValueError(f"JSON invalide : {e}")

    # Créer un graphe
    graph = nx.Graph()

    # Ajouter des nœuds au graphe
    for person in node_data:
        node_id = person['ID']
        graph.add_node(node_id, **person)  # Ajouter le nœud avec les attributs de la personne

    # Ajouter des arêtes au graphe
    for edge_data in edge_list:
        # Vérifier si les clés 'ID_Client' et 'ID_Cuisto' existent
        if 'ID_Client' not in edge_data or 'ID_Cuisto' not in edge_data:
            print(f"Erreur : L'objet arête ne contient pas les clés 'ID_Client' ou 'ID_Cuisto'.  Objet : {edge_data}")
            continue  # Passer à l'arête suivante

        client_id = edge_data['ID_Client']
        cuisto_id = edge_data['ID_Cuisto']
        graph.add_edge(client_id, cuisto_id)  # Ajouter l'arête
    return graph



def welsh_powell(graph, colors):
    """
    Applique l'algorithme de Welsh-Powell pour colorier le graphe.

    Args:
        graph (networkx.Graph): Le graphe à colorier.
        colors (list): Une liste de couleurs à utiliser pour le coloriage.

    Returns:
        dict: Un dictionnaire où les clés sont les IDs des nœuds et les valeurs sont les couleurs attribuées.
              Retourne un dictionnaire vide en cas d'erreur.
    """
    nodes = list(graph.nodes())
    # Créer un dictionnaire pour stocker les degrés des nœuds
    node_degrees = dict(graph.degree())
    # Trier les nœuds par degré décroissant
    sorted_nodes = sorted(nodes, key=lambda node: node_degrees[node], reverse=True)

    # Initialiser le coloriage des nœuds
    node_colors = {}
    for node in nodes:
        node_colors[node] = None  # Aucun nœud n'est coloré au début

    color_index = 0
    # Parcourir les nœuds triés
    for node in sorted_nodes:
        if node_colors[node] is not None:
            continue  # Le nœud est déjà coloré

        if color_index >= len(colors):
            print("Pas assez de couleurs disponibles pour colorier le graphe.")
            return {}  # Retourne un dictionnaire vide pour indiquer une erreur

        node_colors[node] = colors[color_index]  # Colorier le nœud avec la couleur actuelle
        adjacent_nodes = list(graph.neighbors(node)) #récupérer les voisins

        # Colorier les nœuds non adjacents avec la même couleur
        for other_node in sorted_nodes:
            if node_colors[other_node] is None and other_node != node:
                is_adjacent = False
                other_adjacent_nodes = list(graph.neighbors(other_node)) #récupérer les voisins du second noeud
                for colored_node in [n for n in node_colors if node_colors[n] == colors[color_index]]: #pour chaque voisin déjà colorié de la couleur actuelle
                    if colored_node in other_adjacent_nodes: #si un voisin est aussi voisin de other_node
                        is_adjacent = True
                        break
                if not is_adjacent:
                    node_colors[other_node] = colors[color_index]

        color_index += 1

    return node_colors



def visualize_graph(graph, node_colors):
    """
    Visualise le graphe avec les couleurs attribuées.

    Args:
        graph (networkx.Graph): Le graphe à visualiser.
        node_colors (dict): Un dictionnaire où les clés sont les IDs des nœuds et
                            les valeurs sont les couleurs attribuées.
    """
    # Positionnement des nœuds
    pos = nx.spring_layout(graph)

    # Dessiner les nœuds avec les couleurs attribuées
    color_map = [node_colors.get(node) for node in graph.nodes()]
    nx.draw_networkx_nodes(graph, pos, node_color=color_map, node_size=800)

    # Dessiner les arêtes
    nx.draw_networkx_edges(graph, pos, edge_color='gray', width=2)

    # Ajouter des étiquettes de nœud (ID Client)
    labels = {node: node for node in graph.nodes()}
    nx.draw_networkx_labels(graph, pos, labels, font_size=10)

    # Afficher le graphe
    plt.title("Graphe des Clients et des Cuistots (Colorié par Welsh-Powell)")
    plt.axis('off')
    plt.show()

    #Automatisation de la creation d'un graphe 
    #Recherche de mes clients 
    #Serialisation de mes tables

def main():
    """
    Fonction principale pour exécuter l'exemple.
    """
    # Données JSON représentant une liste d'arêtes
    edge_list_json = """
    [
      {
        "ID_Commande": 1,
        "ID_Client": 11,
        "ID_Cuisto": 5,
        "Nom_Menu": "Menu Dégustation Prestige",
        "Nb_Personnes": 5,
        "Pays_Origine": "France",
        "Date_Depart": null,
        "Date_Arrivee": "2024-07-20",
        "Date_Fin": "2024-07-20",
        "Prix_Unitaire": 150.00
      },
      {
        "ID_Commande": 2,
        "ID_Client": 12,
        "ID_Cuisto": 7,
        "Nom_Menu": "Buffet Royal",
        "Nb_Personnes": 20,
        "Pays_Origine": "Italie",
        "Date_Depart": null,
        "Date_Arrivee": "2024-08-10",
        "Date_Fin": "2024-08-12",
        "Prix_Unitaire": 75.50
      },
      {
        "ID_Commande": 3,
        "ID_Client": 13,
        "ID_Cuisto": 6,
        "Nom_Menu": "Menu Végétarien Deluxe",
        "Nb_Personnes": 3,
        "Pays_Origine": "Espagne",
        "Date_Depart": null,
        "Date_Arrivee": "2024-09-01",
        "Date_Fin": "2024-09-01",
        "Prix_Unitaire": 90.00
      },
      {
        "ID_Commande": 4,
        "ID_Client": 1,
        "ID_Cuisto": 3,
        "Nom_Menu": "Réception Gastronomique",
        "Nb_Personnes": 8,
        "Pays_Origine": "France",
        "Date_Depart": null,
        "Date_Arrivee": "2024-10-25",
        "Date_Fin": "2024-10-25",
        "Prix_Unitaire": 120.00
      },
      {
        "ID_Commande": 5,
        "ID_Client": 4,
        "ID_Cuisto": 7,
        "Nom_Menu": "Dîner aux Chandelles Romantique",
        "Nb_Personnes": 2,
        "Pays_Origine": "Italie",
        "Date_Depart": null,
        "Date_Arrivee": "2024-11-15",
        "Date_Fin": "2024-11-15",
        "Prix_Unitaire": 200.00
      },
      {
        "ID_Commande": 6,
        "ID_Client": 5,
        "ID_Cuisto": 1,
        "Nom_Menu": "Menu Traditionnel Breton",
        "Nb_Personnes": 10,
        "Pays_Origine": "France",
        "Date_Depart": null,
        "Date_Arrivee": "2024-12-05",
        "Date_Fin": "2024-12-05",
        "Prix_Unitaire": 60.00
      },
      {
        "ID_Commande": 7,
        "ID_Client": 12,
        "ID_Cuisto": 8,
        "Nom_Menu": "Paella Royale",
        "Nb_Personnes": 8,
        "Pays_Origine": "Espagne",
        "Date_Depart": null,
        "Date_Arrivee": "2025-01-18",
        "Date_Fin": "2025-01-18",
        "Prix_Unitaire": 85.00
      },
      {
        "ID_Commande": 8,
        "ID_Client": 6,
        "ID_Cuisto": 10,
        "Nom_Menu": "Festin Méditerranéen",
        "Nb_Personnes": 15,
        "Pays_Origine": "Grèce",
        "Date_Depart": null,
        "Date_Arrivee": "2025-02-14",
        "Date_Fin": "2025-02-16",
        "Prix_Unitaire": 100.00
      },
      {
        "ID_Commande": 9,
        "ID_Client": 3,
        "ID_Cuisto": 9,
        "Nom_Menu": "Menu Gourmet Parisien",
        "Nb_Personnes": 4,
        "Pays_Origine": "France",
        "Date_Depart": null,
        "Date_Arrivee": "2025-03-22",
        "Date_Fin": "2025-03-22",
        "Prix_Unitaire": 175.00
      },
      {
        "ID_Commande": 10,
        "ID_Client": 7,
        "ID_Cuisto": 5,
        "Nom_Menu": "Banquet de Mariage Classique",
        "Nb_Personnes": 1,
        "Pays_Origine": "France",
        "Date_Depart": null,
        "Date_Arrivee": "2025-04-30",
        "Date_Fin": "2025-04-30",
        "Prix_Unitaire": 95.00
      }
    ]
    """
    node_data_json = """
    [
      {"ID":1,"Nom":"Medhy","Prenom":"Durand","Email":"0645781239","Telephone":"Mdurand@gmail.com","Adresse":"38,Rue Saint-Maur,75011,Paris,Ile_de_France"},
      {"ID":2,"Nom":"Bernard","Prenom":"Armandi","Email":"0781902346","Telephone":"B.Armandi@gmail.com","Adresse":"44,Rue Jean-Baptiste Pigalle,75009,Paris,Ile_de_France"},
      {"ID":3,"Nom":"Tollisso","Prenom":"Joli","Email":"0152839417","Telephone":"T.Joli@gmail.com","Adresse":"129,Rue de Grenelle,75007,Paris,Ile_de_France"},
      {"ID":4,"Nom":"Mendy","Prenom":"Desstreet","Email":"0698213560","Telephone":"M.Desstreet@gmail.com","Adresse":"32,Quai d'Austerlitz,75013,Paris,Ile_de_France"},
      {"ID":5,"Nom":"Giogina","Prenom":"Hover","Email":"0764325789","Telephone":"G.Hover@gmail.com","Adresse":"41,Rue Alain Chartier,75015,Paris,Ile_de_France"},
      {"ID":6,"Nom":"Henri","Prenom":"Lolly","Email":"0633445566","Telephone":"H.Lolly@gmail.com","Adresse":"44,Bd Richard Lenoir,75011,Paris,Ile_de_France"},
      {"ID":7,"Nom":"Kane","Prenom":"Quintila","Email":"0619283745","Telephone":"K.Quintila@gmail.com","Adresse":"4,Avenue de Villiers,75017,Paris,Ile_de_France"},
      {"ID":8,"Nom":"Paul","Prenom":"Megha","Email":"0756789012","Telephone":"P.Nmegha@gmail.com","Adresse":"18,Rue de Paradis,75010,Paris,Ile_de_France"},
      {"ID":9,"Nom":"William","Prenom":"Smith","Email":"0324557859","Telephone":"W.Smith@gmail.com","Adresse":"44,Bd de Picpus,75012,Paris,Ile_de_France"},
      {"ID":10,"Nom":"Durant","Prenom":"Hightower","Email":"0687960514","Telephone":"D.Hightower@gmail.com","Adresse":"59,Place de la République,75011,Paris,Ile_de_France"},
      {"ID":12,"Nom":"Clarisse","Prenom":"Marianna","Email":"","Telephone":"","Adresse":""},
      {"ID":13,"Nom":"Du Pré","Prenom":"Stefiel","Email":"0652497321","Telephone":"parmande@gmail.com","Adresse":""},
      {"ID":14,"Nom":"Paul","Prenom":"Joyau","Email":"0784269712","Telephone":"joyau.kingdom@gmail.com","Adresse":""},
      {"ID":1,"Nom":"Marie","Prenom":"Dupond","Email":"0652851947","Telephone":"Mdupond@gmail.com","Adresse":"4,Rue des Lombards,75004,Paris,Ile_de_France"},
      {"ID":2,"Nom":"Jean-Michel","Prenom":"Pierre","Email":"0793042658","Telephone":"Jmpierre@gmail.com","Adresse":"3,Place du Général Koenig,75017,Paris,Ile_de_France"},
      {"ID":3,"Nom":"Achille","Prenom":"Martin","Email":"0663942750","Telephone":"achMartin@gmail.com","Adresse":"34,Boulevard de la Chapelle,75018,Paris,Ile_de_France"},
      {"ID":4,"Nom":"Darrell","Prenom":"Messi","Email":"0629384173","Telephone":"darMessi@outlook.com","Adresse":"102,Rue d'Alésia,75014,Paris,Ile_de_France"},
      {"ID":5,"Nom":"Benjamin","Prenom":"Marguin","Email":"0775465981","Telephone":"benjiMarguin@yahoo.fr","Adresse":"41,Rue Monsieur le Prince,75006,Paris,Ile_de_France"},
      {"ID":6,"Nom":"Ambroise","Prenom":"Megel","Email":"0744556677","Telephone":"ambMegel@goole.com","Adresse":"12,Rue de Clignancourt ,75018,Paris,Ile_de_France"},
      {"ID":7,"Nom":"Gerard","Prenom":"Piqué","Email":"0631405968","Telephone":"gerPiqué@barcelone.fr","Adresse":"116,Rue d'Alésia,75014,Paris,Ile_de_France"},
      {"ID":8,"Nom":"Thomas","Prenom":"Levallois","Email":"0787960514","Telephone":"thoLevallois@cardinet.com","Adresse":"29,Rue de Rivoli,75004,Paris,Ile_de_France"},
      {"ID":9,"Nom":"Jonathan","Prenom":"Igloo","Email":"0656789012","Telephone":"jonIgloo@gmail.com","Adresse":"112,Bd de Sébastopol,75003,Paris,Ile_de_France"},
      {"ID":10,"Nom":"Isabelle","Prenom":"Routurier","Email":"0698071625","Telephone":"isaRouturier@live.fr","Adresse":"24,Aveneu Carnot,75017,Paris,Ile_de_France"},
      {"ID":13,"Nom":"Omar","Prenom":"Kevin","Email":"07841697","Telephone":"omar@gmail.com","Adresse":""}
    ]
    """

    # Créer le graphe à partir de la liste des arêtes JSON
    try:
        commande_graph = create_graph_from_edge_list(edge_list_json, node_data_json)
    except ValueError as e:
        print(f"Erreur : {e}")
        return

    # Afficher les informations de base sur le graphe
    print("Graphe créé avec succès !")
    print(f"Nombre de nœuds : {commande_graph.number_of_nodes()}")
    print(f"Nombre d'arêtes : {commande_graph.number_of_edges()}")
    print(f"Nœuds : {commande_graph.nodes()}")
    print(f"Arêtes : {commande_graph.edges()}")
    
    # Définir les couleurs à utiliser
    colors = ['red', 'blue', 'green', 'yellow', 'purple', 'orange', 'cyan', 'magenta', 'brown', 'pink']

    # Appliquer l'algorithme de Welsh-Powell
    node_colors = welsh_powell(commande_graph, colors)
    if not node_colors:
        print("Le graphe n'a pas pu être colorié.")
        return
   
    # Afficher les couleurs des nœuds
    print("\nCouleurs des nœuds :")
    for node, color in node_colors.items():
        print(f"Le nœud {node} a la couleur {color}")

      

    # Visualiser le graphe avec les couleurs attribuées
    visualize_graph(commande_graph, node_colors)


if __name__ == "__main__":
    main()

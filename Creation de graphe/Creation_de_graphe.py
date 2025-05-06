import json
import networkx as nx
import matplotlib.pyplot as plt

def create_graph_from_person_json(json_data_list):
    """
    Crée un graphe à partir d'une liste de données JSON représentant des personnes.
    Chaque personne devient un nœud dans le graphe.  Puisqu'il n'y a pas
    d'informations sur les relations dans les données fournies, le graphe
    sera composé de nœuds isolés (sans arêtes).

    Args:
        json_data_list (list): Une liste de chaînes contenant les données JSON.

    Returns:
        networkx.Graph: Un graphe networkx.Graph où chaque personne est un nœud.
    """
    graph = nx.Graph()

    for json_data in json_data_list:
        try:
            # Charger les données JSON
            data = json.loads(json_data)
        except json.JSONDecodeError as e:
            print(f"JSON invalide : {e}")
            continue  # Passer au prochain élément de la liste

        # Ajouter chaque personne comme un nœud au graphe
        for person in data:
            # Utiliser l'ID de la personne comme identifiant du nœud.
            node_id = str(person["ID"])  # Convertir l'ID en chaîne
            graph.add_node(node_id, **person)  # Ajouter le nœud avec les attributs de la personne
    return graph

def visualize_person_graph(graph):
    """
    Visualise le graphe des personnes.  Étant donné que les nœuds n'ont pas de relations
    spécifiées, ils seront affichés comme des points isolés.

    Args:
        graph (networkx.Graph): Le graphe à visualiser.
    """
    # Positionnement des nœuds
    pos = nx.spring_layout(graph)  # ou utilisez une autre mise en page si vous le souhaitez

    # Dessiner les nœuds
    nx.draw_networkx_nodes(graph, pos, node_color='skyblue', node_size=800)

    # Ajouter des étiquettes de nœud (par exemple, les noms)
    labels = {node: data["Nom"] for node, data in graph.nodes(data=True)}
    nx.draw_networkx_labels(graph, pos, labels, font_size=10)

    # Afficher le graphe
    plt.title("Graphe des Personnes")
    plt.axis('off')
    plt.show()

def main():
    """
    Fonction principale pour exécuter l'exemple.
    """
    # Données JSON fournies
    json_data_list = [
        """
        [{"ID":1,"Nom":"Medhy","Prenom":"Durand","Email":"0645781239","Telephone":"Mdurand@gmail.com","Adresse":"38,Rue Saint-Maur,75011,Paris,Ile_de_France"},
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
        """
    ]

    # Créer le graphe à partir des données JSON
    try:
        person_graph = create_graph_from_person_json(json_data_list)
    except ValueError as e:
        print(f"Erreur : {e}")
        return

    # Afficher les informations de base sur le graphe
    print("Graphe créé avec succès !")
    print(f"Nombre de nœuds : {person_graph.number_of_nodes()}")
    print(f"Nœuds : {person_graph.nodes()}")
    #for node in person_graph.nodes(data=True):
    #    print(node)

    # Visualiser le graphe
    visualize_person_graph(person_graph)

if __name__ == "__main__":
    main()

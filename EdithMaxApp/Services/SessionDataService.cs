using EdithMaxApp.Models;
using System.Collections.ObjectModel;

namespace EdithMaxApp.Services;

/// <summary>
/// Service pour gérer les données temporaires en session (dinosaures ajoutés par l'utilisateur).
/// </summary>
public class SessionDataService
{
    private static SessionDataService? _instance;
    private readonly ObservableCollection<DinosaurImage> _sessionDinosaurs = new();

    private SessionDataService()
    {
    }

    public static SessionDataService Instance => _instance ??= new SessionDataService();

    public ObservableCollection<DinosaurImage> SessionDinosaurs => _sessionDinosaurs;

    /// <summary>
    /// Ajoute un dinosaure au début de la collection (en tout premier).
    /// </summary>
    public void AddDinosaur(string title, string description, string imageUri)
    {
        var dinosaur = new DinosaurImage
        {
            Title = title,
            Description = description,
            ImageURL = imageUri,
            DateCreated = DateTime.Now.ToString("g")
        };

        // Insérer au début de la liste
        _sessionDinosaurs.Insert(0, dinosaur);
    }

    /// <summary>
    /// Vide toutes les données de session.
    /// </summary>
    public void ClearSessionData()
    {
        _sessionDinosaurs.Clear();
    }

    /// <summary>
    /// Récupère tous les dinosaures de session.
    /// </summary>
    public IEnumerable<DinosaurImage> GetAllDinosaurs()
    {
        return _sessionDinosaurs.ToList();
    }
}


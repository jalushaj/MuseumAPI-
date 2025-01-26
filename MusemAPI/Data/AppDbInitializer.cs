using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MuseumAPI.Data.Models;
using Projekti.Models;
using System;
using System.Linq;

namespace MuseumAPI.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                
                if (!context.Artists.Any())
                {
                    context.Artists.AddRange(
                        new ArtistModel
                        {
                            Name = "Vincent Van Gogh",
                            Description = "Vincent Willem van Gogh was a Dutch post-impressionist painter who is among the most famous and influential figures in the history of Western art. He is a talented artist known for unique abstract expressions and vibrant colors.",
                            ImageUrl = "images/Vincent_van_Gogh_-_Self-Portrait_-_Google_Art_Project.jpg"
                        },
                        new ArtistModel
                        {
                            Name = "Johannes Vermeer",
                            Description = "An innovative artist blending classical techniques with modern styles.",
                            ImageUrl = "images/Johannes-Vermeer-Self-Portrait-1654-1241569538.jpg"
                        },
                        new ArtistModel
                        {
                            Name = "Caspar David Friedrich",
                            Description = "Known for their stunning landscapes and detailed portrayals of nature.",
                            ImageUrl = "images/Caspar+David+Friedrich+-+Portrait+of+Caspar+David+Friedrich+-+(MeisterDrucke-23607)-3038130751.jpg"
                        },
                        new ArtistModel
                        {
                            Name = "Claude Monet",
                            Description = "Oscar-Claude Monet was a French painter, a founder of French Impressionist painting and the most consistent and prolific practitioner of the movement's philosophy of expressing one's perceptions before nature, especially as applied to plein air landscape painting.",
                            ImageUrl = "images/Claude_Monet_1899_Nadar_crop.jpg"
                        }
                    );

                    context.SaveChanges();
                }

                
                if (!context.Paintings.Any())
                {
                    context.Paintings.AddRange(
                        new PaintingsModel
                        {
                            ArtistId = 1,
                            Name = "Flower Beds in Holland",
                            Description = "Flower Beds in Holland was Van Gogh's first garden painting, in oil paint on canvas mounted on wood.",
                            theme = "Nature",
                            price = 1000,
                            isSold = false,
                            ImageUrl = "images/flowerbeds.jpeg"
                        },
                        new PaintingsModel
                        {
                            ArtistId = 1,
                            Name = "Green Wheat Fields",
                            Description = "An oil-on-canvas painting by Dutch Post-Impressionist Vincent van Gogh.",
                            theme = "Nature",
                            price = 3000,
                            isSold = false,
                            ImageUrl = "images/greenWheat.jpg"
                        }
                    );

                    context.SaveChanges();
                }


                if (!context.Gifts.Any())
                {
                    context.Gifts.AddRange(
                        new GiftsModel
                        {
                            Name = "Starry Night Key Chain",
                            Price = 5,
                            Code = 1687,
                            Url = "images/keyChain.webp"
                        },
                        new GiftsModel
                        {
                            Name = "Notebook",
                            Price = 15,
                            Code = 1236,
                            Url = "images/notebook.jpg"
                        },
                         new GiftsModel
                         {
                             Name = "Gift Set",
                             Price = 40,
                             Code = 1102,
                             Url = "images/giftSet.webp"
                         },
                          new GiftsModel
                          {
                              Name = "Magnet Set",
                              Price = 10,
                              Code = 4601   ,
                              Url = "images/MagnetSet.webp"
                          },
                           new GiftsModel
                           {
                               Name = "Water Bottle",
                               Price = 15,
                               Code = 1106,
                               Url = "images/waterBootle.webp"
                           }
                    );
                    context.SaveChanges();
                }

                if (!context.Work.Any())
                {
                    context.Work.AddRange(
                         new workModel {  Name = "Laocoön and His Sons", Artist = "Agesander, Athenodoros, and Polydorus", Description = "A marble sculpture depicting the Trojan priest Laocoön and his sons being attacked by sea serpents.", Category = "Sculpture", CreationDate = null, CreationDateText = null, Era = "Ancient" },
                new workModel 
                { 
                  Name = "Venus de Milo",
                  Artist = "Unknown",
                  Description = "An ancient Greek statue representing Aphrodite, the goddess of love and beauty.",
                  Category = "Sculpture", 
                  CreationDate = null,
                  CreationDateText = "Approx. 150-100 BC",
                  Era = "Ancient" 
                },
                new workModel {  Name = "Rosetta Stone", Artist = "Unknown", Description = "A granodiorite stele inscribed with a decree in three scripts, key to deciphering Egyptian hieroglyphs.", Category = "Artifact", CreationDate = null, CreationDateText = "196 BC", Era = "Ancient" },
                new workModel {  Name = "The Codex Hammurabi", Artist = "Hammurabi", Description = "One of the earliest and most complete written legal codes from ancient Mesopotamia, inscribed on a large stone stele.", Category = "Artifact", CreationDate = null, CreationDateText = "1754 BC", Era = "Ancient" },
                new workModel {  Name = "The Book of Kells", Artist = "Unknown", Description = "A famous illuminated manuscript containing the four Gospels, created by Celtic monks.", Category = "Manuscript", CreationDate = null, CreationDateText = "800-01-01", Era = "Medieval" },
                new workModel { Name = "The Bayeux Tapestry", Artist = "Unknown", Description = "A 70-meter-long embroidered cloth depicting the events leading up to the Norman conquest of England.", Category = "Tapestry", CreationDate = null, CreationDateText = "1070-01-01", Era = "Medieval" },
                new workModel {  Name = "The Arnolfini Portrait", Artist = "Jan van Eyck", Description = "A famous oil painting depicting Giovanni di Nicolao di Arnolfini and his wife Costanza Trenta.", Category = "Painting", CreationDate = null, CreationDateText = "1434-01-01", Era = "Medieval" },
                new workModel {  Name = "The Last Supper", Artist = "Leonardo da Vinci", Description = "A famous fresco depicting the moment Jesus announces that one of his disciples will betray him.", Category = "Painting", CreationDate = null, CreationDateText = "1495-01-01", Era = "Renaissance" },
                new workModel {  Name = "David", Artist = "Michelangelo", Description = "A marble sculpture representing the Biblical hero David, famous for its depiction of human anatomy.", Category = "Sculpture", CreationDate = null, CreationDateText = "1501-01-01", Era = "Renaissance" },
                new workModel {  Name = "Starry Night", Artist = "Vincent van Gogh", Description = "A famous painting known for its swirling, expressive representation of the night sky over Saint-Rémy-de-Provence.", Category = "Painting", CreationDate = null, CreationDateText = "1889-01-01", Era = "Modern" },
                new workModel {  Name = "The Persistence of Memory", Artist = "Salvador Dalí", Description = "A surrealist painting famous for its melting clocks, symbolizing the fluidity of time.", Category = "Painting", CreationDate = null, CreationDateText = "1931-01-01", Era = "Modern" },
                new workModel { Name = "Guernica", Artist = "Pablo Picasso", Description = "A large mural painting depicting the bombing of the Basque town of Guernica during the Spanish Civil War.", Category = "Painting", CreationDate = null, CreationDateText = "1937-01-01", Era = "Modern" },
                new workModel { Name = "The Thinker", Artist = "Auguste Rodin", Description = "A bronze sculpture depicting a man in deep contemplation, originally conceived as part of a larger work, The Gates of Hell.", Category = "Sculpture", CreationDate = null, CreationDateText = "1880-01-01", Era = "Modern" },
                new workModel { Name = "The Scream", Artist = "Edvard Munch", Description = "An iconic expressionist painting symbolizing existential angst and fear.", Category = "Painting", CreationDate = null, CreationDateText = "1893-01-01", Era = "Modern" },
                new workModel {  Name = "The Kiss", Artist = "Gustav Klimt", Description = "A famous Art Nouveau painting depicting an intimate embrace, adorned with gold leaf.", Category = "Painting", CreationDate = null, CreationDateText = "1907-01-01", Era = "Modern" },
                new workModel {  Name = "The Lamentation", Artist = "Giotto di Bondone", Description = "A fresco that depicts the mourning of Christ, one of the key pieces of early Renaissance painting.", Category = "Fresco", CreationDate = null, CreationDateText = "1305-01-01", Era = "Medieval" },
                new workModel {  Name = "The Tres Riches Heures", Artist = "Unknown", Description = "A richly illuminated manuscript, considered the best example of French Gothic art.", Category = "Manuscript", CreationDate = null, CreationDateText = "1410-01-01", Era = "Medieval" },
                new workModel {  Name = "The Wilton Diptych", Artist = "Unknown", Description = "An English diptych depicting King Richard II and the Virgin Mary, showcasing late Gothic style.", Category = "Altarpiece", CreationDate = null, CreationDateText = "1395-01-01", Era = "Medieval" },
                new workModel {  Name = "The Annunciation", Artist = "Simone Martini", Description = "A masterpiece of Gothic art, a painting that shows the Virgin Mary receiving the message of Christ’s birth.", Category = "Painting", CreationDate = null, CreationDateText = "1333-01-01", Era = "Medieval" },
                new workModel {  Name = "The School of Athens", Artist = "Raphael", Description = "A fresco representing philosophy and knowledge, with many famous ancient philosophers.", Category = "Fresco", CreationDate = null, CreationDateText = "1510-01-01", Era = "Renaissance" },
                new workModel {  Name = "The Statue of Zeus at Olympias", Artist = "Phidias", Description = "One of the Seven Wonders of the Ancient World, a massive seated figure of Zeus made of ivory and gold.", Category = "Sculpture", CreationDate = null, CreationDateText = "435 BC", Era = "Ancient" }

                );
                    context.SaveChanges();
                }

                try
                {
                    if (!context.Users.Any())
                    {
                        context.Users.AddRange(
                            new UserModel
                            {
                                Username = "admin",
                                Email = "admin@gmail.com",
                                Password = BCrypt.Net.BCrypt.HashPassword("admin123"),
                                FirstName = "Admin",
                                LastName = "1",
                                PhoneNumber = "1234567890",
                                Address = "Durres",
                                City = "Durres",
                                Country = "Albania",
                                ZipCode = "2001",
                                Role = "Admin"
                            }
                        );
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error seeding users: " + ex.Message);
                }
            }
        }
    }
}

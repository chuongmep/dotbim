﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace dotbim
{
    /// <summary>
    /// Represents an element in a BIM file.
    /// </summary>
    [Serializable]
    [JsonObject("element")]
    public class Element
    {
        private string _guid;

        /// <summary>
        /// The identifier of the mesh associated with the element.
        /// </summary>
        [JsonProperty("mesh_id")]
        public int MeshId { get; set; }

        /// <summary>
        /// The position of the element.
        /// </summary>
        [JsonProperty("vector")]
        public Vector Vector { get; set; }

        /// <summary>
        /// The rotation of the element.
        /// </summary>
        [JsonProperty("rotation")]
        public Rotation Rotation { get; set; }

        /// <summary>
        /// The globally unique identifier for the element.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if the value is not a valid globally unique identifier.
        /// </exception>
        [JsonProperty("guid")]
        public string Guid
        {
            get => _guid;
            set
            {
                if (System.Guid.TryParse(value, out _))
                {
                    _guid = value;
                }
                else
                {
                    throw new ArgumentException("Guid is not correct. Create Guid with proper component.");
                }
            }
        }

        /// <summary>
        /// The type of the element.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The color of the element.
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }
        
        /// <summary>
        /// The list of integers, that determine face colors of a mesh.
        /// They should be organized like this: [r1, g1, b1, a1, r2, g2, b2, a2, r3, g3, b3, a3, ... rn, gn, bn, an]
        /// E.g. list like: [255, 0, 0, 255, 135, 206, 235, 255, 255, 255, 255, 255]
        /// means first triangle should be colored as red (255,0,0,255),
        /// second as skyblue (135,206,235,255),
        /// third as white (255,255,255,255).
        /// </summary>
        [JsonProperty("face_colors", NullValueHandling=NullValueHandling.Ignore)]
        public List<int> FaceColors { get; set; }

        /// <summary>
        /// Additional information about the element.
        /// </summary>
        [JsonProperty("info")]
        public Dictionary<string, string> Info { get; set; }
    }

}
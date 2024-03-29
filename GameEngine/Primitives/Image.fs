module GameEngine.Image

open GameEngine.Rgba

type Image =
  { Data: Rgba array
    Width: int
    Height: int
  }
  static member Create width height =
    { Data = Array.create (width*height) { R = 0uy ; G = 0uy ; B = 0uy ; A = 0uy }
      Width = width
      Height = height
    }
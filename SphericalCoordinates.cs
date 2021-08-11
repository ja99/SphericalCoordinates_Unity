using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalCoordinates : MonoBehaviour
{
    /// <summary>converts Carteisian Coordinates to Spherical
    ///  see: https://www.omnicalculator.com/math/spherical-coordinates</summary>
    public static SphericalCoordinate CarteisianToSpherical(Vector3 direction)
    {
        float r = direction.magnitude;
        float thetha = Mathf.Acos(direction.y / r);
        float phi = Mathf.Atan2(direction.z, direction.x);

        return new SphericalCoordinate(r, thetha * Mathf.Rad2Deg, phi * Mathf.Rad2Deg);
    }

    /// <summary>converts Spherical Coordinates to Catreisian
    ///  see: https://www.omnicalculator.com/math/spherical-coordinates</summary>
    public static Vector3 SphericalToCarteisian(SphericalCoordinate sCoordinate)
    {
		sCoordinate.phi = sCoordinate.phi % 360f;
		sCoordinate.thetha = sCoordinate.thetha % 360f;
        float x = sCoordinate.r * Mathf.Sin(sCoordinate.thetha * Mathf.Deg2Rad) * Mathf.Cos(sCoordinate.phi * Mathf.Deg2Rad);
        float z = sCoordinate.r * Mathf.Sin(sCoordinate.thetha * Mathf.Deg2Rad) * Mathf.Sin(sCoordinate.phi * Mathf.Deg2Rad);
        float y = sCoordinate.r * Mathf.Cos(sCoordinate.thetha * Mathf.Deg2Rad);

        return new Vector3(x, y, z);
    }
}

/// <summary>Spherical Coordinate implementation.
///  see: https://www.omnicalculator.com/math/spherical-coordinates</summary>
public struct SphericalCoordinate
{
    public float r;
    public float thetha;
    public float phi;

    public SphericalCoordinate(float r, float thetha, float phi)
    {
        this.r = r;
        this.thetha = thetha;
        this.phi = phi;
    }

	public static SphericalCoordinate operator +(SphericalCoordinate a, SphericalCoordinate b)
        => new SphericalCoordinate(a.r + b.r, a.thetha + b.thetha, a.phi + b.phi);

    public static SphericalCoordinate operator -(SphericalCoordinate a, SphericalCoordinate b)
        => new SphericalCoordinate(a.r - b.r, a.thetha - b.thetha, a.phi - b.phi);

    public override string ToString()
    {
        string s = "(";
        s += "r: " + this.r;
        s += ", thetha: " + this.thetha;
        s += ", phi: " + this.phi + ")";
        return s;
    }
}

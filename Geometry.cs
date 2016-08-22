using System;

namespace Geometry
{
	public class Coordinate
	{
		protected double x,y,z;
		protected double distance_from_origin;

		public Coordinate (double x, double y, double z)
		{
			this.x = x;
			this.y = y; 
			this.z = z;
			UpdateMembers ();
		}

		public void TranslateBy (double dx, double dy, double dz)
		{
			this.x = x + dx;	
			this.y = y + dy;	
			this.z = z + dz;
			UpdateMembers ();
		}

		public void ScaleBy (double ax, double ay, double az)
		{
			this.x = x + ax;	
			this.y = y + ay;	
			this.z = z + az;
			UpdateMembers ();
		}

		public void Normalize ()
		{
			this.x = x/this.distance_from_origin;	
			this.y = y/this.distance_from_origin;	
			this.z = z/this.distance_from_origin;
			UpdateMembers ();
		}

		public void GetDistanceFromOrigin ()
		{
			double rsq = this.x*this.x+this.y*this.y+this.z*this.z;
			this.distance_from_origin = Math.Sqrt(rsq);
		}


		public void RotateAround (double vx, double vy, double vz,double theta)
		{
			double Cos_th  = Math.Cos(theta);
			double Sin_th  = Math.Sin(theta);
	
		    	double A = (this.x*vx+this.y*vy+this.z*vz)*(1-Cos_th);
			double B = Sin_th;
			double C = Cos_th;
			double X = vx*A + this.x*B + (-vz*this.y+vy*this.z)*C;	
			double Y = vy*A + this.y*B + ( vz*this.x+vx*this.z)*C;	
			double Z = vz*A + this.z*B + (-vy*this.x+vx*this.y)*C;	

			this.x = X;
			this.y = Y;
			this.z = Z;
		}

		public void UpdateMembers ()
		{
			GetDistanceFromOrigin();
		}

		public double X
		{
			get { return this.x; }
		}

		public double Y
		{
			get { return this.y; }
		}

		public double Z
		{
			get { return this.z; }
		}

		public double distanceFromOrigin
		{
			get { return this.distance_from_origin; }
		}


	}
}

